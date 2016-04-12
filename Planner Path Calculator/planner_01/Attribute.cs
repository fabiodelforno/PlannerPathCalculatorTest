using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner_Path_Calculator
{

    public class Attribute
    {
        public Attribute() { }
        public Attribute(string n, int v)
        {
            this.NameAttribute = n;
            this.Value = v;
        }

        [JsonProperty("NameAttribute")]
        public string NameAttribute { get; set; }
        [JsonProperty("Value")]
        public int Value { get; set; }


        public override string ToString()
        {
            return string.Format("\n  Attribute: " + NameAttribute + " Value: " + Value);
        }
    }
}
