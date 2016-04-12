using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Planner_Path_Calculator
{

    public class Vertex
    {
        
        [JsonProperty("NameVertex")]
        public string NameVertex { get; set; }
        [JsonProperty("Attributes")]
        public List<Attribute> Attributes { get; set; }

        public override string ToString()
        {
            string vertex = string.Format("\n Vertex:" + NameVertex);
            foreach (Attribute item in Attributes)
            {
                vertex += item.ToString();
            }
            return vertex;
        }

    }
}
