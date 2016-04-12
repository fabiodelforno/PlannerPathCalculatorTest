using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace Engine
{
    class Engine
    {
        String vertexStart = "";
        String vertexEnd = "";
        String tipo = "";
        String[] Attributi;
        public Engine(String[] args)
        {

            //info user
            /*string m1 = "Inserire il percorso dell'albero da calcolare, utilizzare il seguente formato";
            string sintassi = "VertexNameStart VertexNameEnd";*/
            string error = "input non valido";
            //string info = "press enter per avviare engine";

            //Console.WriteLine(m1);
            //Console.WriteLine(sintassi);
            //read line insert*/
            tipo = args[0];
             vertexStart = args[1];
            vertexEnd = args[2];
          

            Attributi = new String[args.Length - 2];
            int lungar = args.Length - 1;
            for (int i = 2; i <= lungar; i++)
            {
                Attributi[i - 2] = args[i];
            }

            if (vertexStart == null || vertexEnd == null)
            {
                Console.WriteLine(error);
            }

            //Console.WriteLine("Letto: " + "\nVertexNameStart: " + vertexStart + "\nVertexNameEnd: " + vertexEnd);
            //Console.WriteLine(info);
            //Console.ReadKey();
        }


        public void engine(SqlConnection sdwDBConnection)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Esegue una stored procedure che restituisce percorso e attributi
            string get_values = "EXEC search_route '" + tipo + "', '" + vertexStart + "', '" + vertexEnd + "'";
          

            SqlCommand exec = new SqlCommand(get_values, sdwDBConnection);

            SqlDataReader parse_values = null;
            try
            {
                parse_values = exec.ExecuteReader();
            }
            catch
            {
                Console.WriteLine("Tempo scaduto o il server non risponde.");
            }

            DataTable dataTable = new DataTable();
            //conterrà i valori restituiti dalla stored procedure
            if (parse_values != null)
                dataTable.Load(parse_values);

            if (dataTable.Rows.Count != 0)
            {
                //questa lista contiene i nomi dei nodi da attraversare...
                List<String> NomiVertici = new List<String>();

                DataColumn column = dataTable.Columns[0];
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!NomiVertici.Contains(row[column.ColumnName].ToString()))
                    {
                        NomiVertici.Add(row[column.ColumnName].ToString());
                    }
                }

                //...e viene stampata in output
                Console.WriteLine("\nPercorso:");
                foreach (String Name in NomiVertici)
                {
                    Console.WriteLine(Name);
                }

                //questa lista contiene tutti gli attributi dei nodi del percorso (Ogni attributo è costituito da Nome e Valore)
                List<Attribute> attr = new List<Attribute>();

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < Attributi.Length; i++)
                    {
                        String a = row[dataTable.Columns[1]].ToString();
                        if (Attributi[i].ToString() == row[dataTable.Columns[1]].ToString())
                        {

                            attr.Add(new Attribute(row[dataTable.Columns[1]].ToString(), Convert.ToInt16(row[dataTable.Columns[2]])));
                        }
                    }
                    
                }

                //esegue la somma di tutti gli attributi dello stesso tipo (nome), usando il metodo calcAttributo() della classe Attribute.
                Console.WriteLine("\nSomma degli attributi:");
                while (attr.Count != 0)
                {
                    string attr_name_corrente = attr[0].getNameAttr();

                    Console.WriteLine(attr_name_corrente + "=" + " " + attr[0].calcAttributo(attr));

                    //rimuove dalla lista attr tutti gli attributi che sono già stati sommati
                    List<Attribute> temp = new List<Attribute>();
                    for (int i = 0; i < attr.Count; i++)
                    {
                        if (attr[i].getNameAttr() != attr_name_corrente)
                        {
                            temp.Add(attr[i]);
                        }
                    }
                    attr = temp;
                }
            }
            else
            {
                Console.WriteLine("Percorso non trovato");
            }

            stopWatch.Stop();
            
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);



        }

    }
}