using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Planner_Path_Calculator
{

    public class Tree
    {
        public Tree() { }
        public Tree(string n, List<Vertex> v, List<Edge> e)
        {
            this.NameTree = n;
            this.Vertexs = v;
            this.Edges = e;
        }
        //serve a Json per avere una corrispondenza markup-method
        [JsonProperty("NameTree")]
        public string NameTree { get; set; }
        [JsonProperty("Vertexs")]
        public List<Vertex> Vertexs { get; set; }
        [JsonProperty("Edges")]
        public List<Edge> Edges { get; set; }

        public override string ToString()
        {
            string tree = string.Format("\nTree:" + NameTree);

            foreach (Vertex item in Vertexs)
            {
                tree += item.ToString();
            }

            foreach (Edge item in Edges)
            {
                tree += item.ToString();
            }
            return tree;
        }
    }
}
