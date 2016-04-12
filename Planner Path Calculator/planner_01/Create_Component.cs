using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace Planner_Path_Calculator
{
    class Create_Component
    {
        List<Vertex> listV = new List<Vertex>();
        List<Edge> listE = new List<Edge>();
        string[] attrList = new string[10];

        //lista temporanea per informazioni sui vertici
        List<temp_vertex> tmpVert = new List<temp_vertex>();

        Random r = new Random();

        public void createJsonFile(string nameTree, string path, int depth, int splitsize, string[] attrs)
        {            
            listV.Clear();
            listE.Clear();
            tmpVert.Clear();

            attrList = attrs;

            //avvia la procedura per calcolare l'albero
            initTree(depth, splitsize);

            Tree treeCreate = new Tree(nameTree, listV, listE);
            Console.WriteLine("" + listV.Last<Vertex>().ToString());
            

            writeJsonFile(treeCreate, path);
            
            
        }

        private void writeJsonFile(Tree treeCreate, string path)
        {
            FileStream fs = File.Open(path, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            JsonTextWriter jw = new JsonTextWriter(sw);
            jw.Formatting = Formatting.Indented;
            JsonSerializer serializza = new JsonSerializer();
            serializza.Serialize(jw, treeCreate);

            jw.Flush();
            fs.Close();
        }

        //inizializza l'albero
        private void initTree(int depth, int split_size)
        {
            //inizializza la radice
            Vertex root = new Vertex();
            root.NameVertex = "v1";
            attrCreate(root);

            listV.Add(root);

            //vertice di appoggio
            temp_vertex tmp = new temp_vertex(root.NameVertex, 1);
            tmpVert.Add(tmp);

            //iterazioni breath-first per l'istanziazione dell'albero
            int tmpSplit = split_size;
            while (depth > tmp.level)
            {

                while (tmpSplit != 0)
                {

                    createVertex(tmp.name_vertex, tmp.level);
                    tmpSplit -= 1;
                }
                tmpSplit = split_size;

                //dopo aver generato tutti i figli di un vertice, questo può essere dalla lista di appoggio
                tmpVert.Remove(tmp);
                tmp = tmpVert.First();

            }
        }

        //crea un nodo
        private void createVertex(string padre, int lev)
        {
            //inizializza nodo
            Vertex nodo = new Vertex();
            nodo.NameVertex = "v" + (1 + int.Parse(tmpVert.Last().name_vertex.Substring(1)));
            attrCreate(nodo);

            listV.Add(nodo);

            temp_vertex tmp = new temp_vertex(nodo.NameVertex, lev + 1);
            tmpVert.Add(tmp);

            createEdge(padre, nodo);
        }

        //crea un arco per ogni vertice generato
        private void createEdge(string padre, Vertex figlio)
        {
            Edge e = new Edge();
            e.SourceV = figlio.NameVertex;
            e.DestV = padre;
            attrCreate(e);
            listE.Add(e);
        }

        ////aggiunge una lista di attributi a un oggetto
        private void attrCreate(Object o)
        {
            
            if (o is Vertex)
            {
                Vertex v = (Vertex)o;
                List<Attribute> attrV = new List<Attribute>();

                for (int i = 0; i < 5; i++)
                {
                    if (attrList[i] != "")
                    {
                        Attribute a = new Attribute();
                        a.NameAttribute = attrList[i];
                        attrV.Add(a);
                    }

                }                
                
                foreach (Attribute item in attrV)
                {
                    item.Value = r.Next(1000);
                }

                v.Attributes = attrV;
            }

            if (o is Edge)
            {
                Edge e = (Edge)o;
                List<Attribute> attrE = new List<Attribute>();

                for (int i = 5; i < 10; i++)
                {
                    if (attrList[i] != "")
                    {
                        Attribute a = new Attribute();
                        a.NameAttribute = attrList[i];
                        attrE.Add(a);
                    }
                }
                
                foreach (Attribute item in attrE)
                {
                    item.Value = r.Next(1000);
                }

                e.Attributes = attrE;
            }
        }

    }

    public class temp_vertex
    {
        public string name_vertex;
        public int level;

        public temp_vertex(string name, int lev)
        {
            this.name_vertex = name;
            this.level = lev;
        }
    }
}
