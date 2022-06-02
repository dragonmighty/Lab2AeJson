using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace labparser.Model
{
    public class PhoneLabel
    {
        [JsonProperty("startSeconds")]
        public double StartSeconds { get; set; }
        [JsonProperty("endSeconds")]
        public double EndSeconds { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("lipShape")]
        public string LipShape { get; set; }

        public PhoneLabel(double StartSeconds, double EndSeconds, string Phone, string LipShape)
        {
            this.StartSeconds = StartSeconds;
            this.EndSeconds = EndSeconds;
            this.Phone = Phone;
            this.LipShape = LipShape;
        }
    }
}
