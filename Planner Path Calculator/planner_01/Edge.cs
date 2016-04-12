using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner_Path_Calculator
{

    public class Edge
    {
        [JsonProperty("SourceV")]
        public string SourceV { get; set; }
        [JsonProperty("DestV")]
        public string DestV { get; set; }
        [JsonProperty("Attributes")]
        public List<Attribute> Attributes { get; set; }


        public override string ToString()
        {
            string edge = string.Format("\n SourceVertex: " + SourceV + " DestVertex: " + DestV);
            foreach (Attribute item in Attributes)
            {
                edge += item.ToString();
            }
            return edge;
        }
    }
}

