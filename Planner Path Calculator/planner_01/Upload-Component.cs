using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Types;

namespace Planner_Path_Calculator
{
    class Upload_Component
    {
        
        SqlConnection sdwDBConnection;


        String Tipo = String.Empty;

        Dictionary<object, string> Vertex_Attrs_List = new Dictionary<object, string>();
        Dictionary<object, string> Edge_Attrs_List = new Dictionary<object, string>();

        //qui verranno salvati di volta in volta tutti gli id gerarchici generati per i vertici (per non estrarli di nuovo dal DB)
        Dictionary<string, SqlHierarchyId> Vertex_position = new Dictionary<string, SqlHierarchyId>();


        public Upload_Component()
        {
            String FileConnect = Environment.CurrentDirectory;
            String sdwConnectionString = System.IO.File.ReadAllText(FileConnect + @"\Config.txt");
            Console.WriteLine(sdwConnectionString);
            // Create a connection
            sdwDBConnection = new SqlConnection(sdwConnectionString);
            // Open the connection
            try
            {
                sdwDBConnection.Open();
            }
            catch
            {
                MessageBox.Show("Accertarsi che i parametri di connessione siano corretti.");
            }

            //Controlla che sia presente il nodo super-root
            string show = "SELECT COUNT(*) FROM Vertex_Edge WHERE ID_Gerarchico = hierarchyId::GetRoot(); ";
            SqlCommand queryCommand = new SqlCommand(show, sdwDBConnection);
            if (Convert.ToInt16(queryCommand.ExecuteScalar()) == 0)
                insert_Super_Root();
        }

        private static string getConnectionString()
        {
            string envNamePc = Environment.GetEnvironmentVariable("COMPUTERNAME");
            return "Data Source = " + envNamePc + @"\SQLEXPRESS;"
                    + "user id=sa; password=planner;"
                    + "Initial Catalog = Tree_Collection;";
        }

        void insert_Super_Root()
        {
            string Name = "super_root";

            //inserisce nodo super-root
            SqlCommand root = new SqlCommand("INSERT Vertex_Edge (ID_Gerarchico, Name, Tipo) SELECT hierarchyId::GetRoot(), '" + Name + "', 'nessun tipo'", sdwDBConnection);
            root.ExecuteNonQuery();
        }

        void insert_Root(Vertex radice)
        {
            SqlCommand root = new SqlCommand();
            root.Connection = sdwDBConnection;

            //individua l'ID_Gerarchico che dovrà avere (sarà un figlio del nodo Super_Root)            
            string query = "DECLARE @last_node hierarchyid = (SELECT MAX(ID_Gerarchico) FROM Vertex_Edge WHERE ID_Gerarchico.GetAncestor(1) = hierarchyid::GetRoot()) ";
            query = query + "SELECT hierarchyid::GetRoot().GetDescendant(@last_node, NULL) ";
            root.CommandText = query;
            SqlHierarchyId pos = SqlHierarchyId.Parse(root.ExecuteScalar().ToString());

            //salva nel dizionario Vertex_position la posizione del vertice
            Vertex_position.Add(radice.NameVertex, pos);

            //inserisce nodo root
            query = "INSERT Vertex_Edge (ID_Gerarchico, Name, Tipo) VALUES(CAST('" + pos + "' AS hierarchyid), '" + radice.NameVertex + "', '" + Tipo + "') ";
            root.CommandText = query;
            root.ExecuteNonQuery();

            //inserisce i suoi attributi (solo quelli in Vertex_Attr_List perchè la root non comprende un arco superiore)
            foreach (var Id_Attr in Vertex_Attrs_List.Keys)
            {
                int value = radice.Attributes.Find(x => x.NameAttribute == Vertex_Attrs_List[Id_Attr]).Value;

                SqlCommand attr = new SqlCommand("DECLARE @Nodo uniqueidentifier SELECT @Nodo = ID_Blocco FROM Vertex_Edge WHERE Tipo = '" + Tipo + "' AND Name = '" + radice.NameVertex + "'; INSERT AttrUsage (ObjectUid,AttrDef, Value) VALUES (@Nodo, '" + Id_Attr + "','" + value + "')", sdwDBConnection);
                attr.ExecuteNonQuery();
            }

        }

        public bool start_upload(Tree albero)
        {

            Tipo = albero.NameTree;

            //Controlla che NON sia già presente un albero dello stesso tipo
            string show = "SELECT COUNT(*) FROM Vertex_Edge WHERE Tipo = '" + Tipo + "'; ";
            SqlCommand queryCommand = new SqlCommand(show, sdwDBConnection);

            if (Convert.ToInt16(queryCommand.ExecuteScalar()) == 0)
            {
                int c = 1;

                #region inserimento_attributi nella tabella AttrDef (se non esistono)

                foreach (Attribute attr in albero.Vertexs.First().Attributes)
                {
                    insert_Attr_Nodo(attr.NameAttribute);
                }
                foreach (Attribute attr in albero.Edges.First().Attributes)
                {
                    insert_Attr_Arco(attr.NameAttribute);
                }

                #endregion

                //inserimento radice
                insert_Root(albero.Vertexs.First());

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sdwDBConnection;

                #region inserimento nodi nella tabella Vertex_Edge
                //tabella di appoggio da inviare alla Stored Procedure BulkInsert_Blocks
                DataTable vertex_table = new DataTable();
                vertex_table.Clear();
                vertex_table.Columns.Add("pos");
                vertex_table.Columns.Add("nome");
                vertex_table.Columns.Add("tipo");


                SqlCommand insert_blocks = new SqlCommand("BulkInsert_Blocks", sdwDBConnection);
                insert_blocks.CommandType = CommandType.StoredProcedure;

                //copia della lista di archi dall'oggeto Tree ricevuto in input
                List<Edge> careofedge = new List<Edge>(albero.Edges);

                //recupera la split-size almeno uguale a 1
                int splitsize = 0, k = 0;
                
                while (k < careofedge.Count && careofedge[k].DestV == "v1" )
                {
                    splitsize++;
                    k++;
                }
                Console.WriteLine("split_size: " + splitsize);
                //per ogni arco della lista si aggiunge alla tabella di appoggio vertex_table il vertici SourceV, 
                //mentre DestV non viene inserito, perchè equivale al SourceV dell'iterazione precedente
                while (careofedge.Count != 0)
                {
                    Edge arco;
                    string padre;
                    SqlHierarchyId padre_hid;
                    SqlHierarchyId current_pos;

                    for (int j = 0; j < splitsize; j++)
                    {
                        arco = careofedge[j];
                        padre = arco.DestV;
                        padre_hid = Vertex_position[padre];

                        if (j == 0) //il primo figlio usa GetDescendant(null, null)
                        {
                            current_pos = padre_hid.GetDescendant(SqlHierarchyId.Null, SqlHierarchyId.Null);
                            Vertex_position.Add(arco.SourceV, current_pos);
                            vertex_table.Rows.Add(current_pos, arco.SourceV, Tipo);
                        }
                        else //i figli successivi usano GetDescendant(figlio-sinistro, null)
                        {
                            current_pos = padre_hid.GetDescendant(current_pos, SqlHierarchyId.Null);
                            Vertex_position.Add(arco.SourceV, current_pos);
                            vertex_table.Rows.Add(current_pos, arco.SourceV, Tipo);
                        }

                    }
                    //si rimuovono dalla lista di appoggio i blocchi appena inseriti sul DB
                    
                    careofedge.RemoveRange(0, splitsize);
                }

                //quando la lista di appoggio è vuota si arriva qui
                //temp è una tabella di appoggio necessaria a splittare le righe di vertex_tabel in 
                //blocchi da 5000 righe per non sovraccaricare l'esecuzione della Stored Procedure
                DataTable temp = new DataTable();
                temp.Columns.Add("pos");
                temp.Columns.Add("nome");
                temp.Columns.Add("tipo");

                SqlParameter blocchi = insert_blocks.Parameters.AddWithValue("@blocchi", temp);
                blocchi.SqlDbType = SqlDbType.Structured;

                int p = 0;

                while (p != vertex_table.Rows.Count)
                {
                    temp.Rows.Add(vertex_table.Rows[p].ItemArray);

                    if (((p + 1) % 5000) == 0)
                    {
                        try
                        {
                            insert_blocks.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Tempo per l'operazione scaduto o il server non risponde.");
                        }
                        temp.Clear();
                    }

                    p++;

                }


                try
                {
                    insert_blocks.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Tempo per l'operazione scaduto o il server non risponde.");
                }

                temp.Clear();
                vertex_table.Clear();
                #endregion



                //si eseguono le query di inserimento degli attributi
                #region inserimento attributi nella tabella AttrUsage

                //estrazione uniqueidentifiers dei vertici di tipo considerato
                string query = "SELECT ID_Blocco, Name FROM Vertex_Edge WHERE Tipo = '" + Tipo + "' ";
                cmd.CommandText = query;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable Vertex_table = new DataTable();
                Vertex_table.Load(reader);

                string id;
                string name = string.Empty;

                //tabella di appoggio da inviare alla Stored Procedure BulkInsert_Atrrs
                DataTable attr_usage_table = new DataTable();
                attr_usage_table.Clear();
                attr_usage_table.Columns.Add("ID_Blocco");
                attr_usage_table.Columns.Add("ID_Attr");
                attr_usage_table.Columns.Add("Valore");

                SqlCommand insert_attrs = new SqlCommand("BulkInsert_Attrs", sdwDBConnection);
                insert_attrs.CommandType = CommandType.StoredProcedure;
                SqlParameter valori = insert_attrs.Parameters.AddWithValue("@valori", attr_usage_table);
                valori.SqlDbType = SqlDbType.Structured;

                c = 1;

                //per ogni vertice si inseriscono gli attributi
                for (int i = 1; i < Vertex_table.Rows.Count; i++)
                {
                    //recupera id e nome del vertice
                    id = Vertex_table.Rows[i]["ID_Blocco"].ToString();
                    name = (string)Vertex_table.Rows[i]["Name"];

                    //Si riempie la tabella AttrUsage con l'id del vertice, l'id dell'attributo e il suo valore
                    foreach (var Id_Attr in Vertex_Attrs_List.Keys)
                    {
                        int value = albero.Vertexs[i].Attributes.Find(x => x.NameAttribute == Vertex_Attrs_List[Id_Attr]).Value;

                        attr_usage_table.Rows.Add(id, Id_Attr, value);
                    }
                    foreach (var Id_Attr in Edge_Attrs_List.Keys)
                    {
                        Edge arcosup = albero.Edges[i - 1];
                        int value = arcosup.Attributes.Find(x => x.NameAttribute == Edge_Attrs_List[Id_Attr]).Value;

                        attr_usage_table.Rows.Add(id, Id_Attr, value);
                    }

                    if (i == (2000 * c))
                    {
                        try
                        {
                            insert_attrs.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Tempo per l'operazione scaduto o il server non risponde.");
                        }

                        attr_usage_table.Clear();
                        c++;
                    }


                }


                try
                {
                    insert_attrs.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Tempo per l'operazione scaduto o il server non risponde.");
                }


                #endregion

                return true;
            }
            else
            {
                return false;
            }

        }


        void insert_Attr_Nodo(string name)
        {
            SqlCommand insertattr = new SqlCommand("IF NOT EXISTS (SELECT * FROM AttrDef WHERE AttrName = '" + name + "') BEGIN INSERT INTO AttrDef(AttrName) VALUES('" + name + "') END", sdwDBConnection);
            insertattr.ExecuteNonQuery();
            SqlCommand query = new SqlCommand("SELECT AttrDefUid FROM AttrDef WHERE AttrName = '" + name + "'", sdwDBConnection);
            Vertex_Attrs_List.Add(query.ExecuteScalar(), name);

        }

        void insert_Attr_Arco(string name)
        {
            SqlCommand insertattr = new SqlCommand("IF NOT EXISTS (SELECT * FROM AttrDef WHERE AttrName = '" + name + "') BEGIN INSERT INTO AttrDef(AttrName) VALUES('" + name + "') END", sdwDBConnection);
            insertattr.ExecuteNonQuery();
            SqlCommand query = new SqlCommand("SELECT AttrDefUid FROM AttrDef WHERE AttrName = '" + name + "'", sdwDBConnection);
            Edge_Attrs_List.Add(query.ExecuteScalar(), name);
        }

    }
}
