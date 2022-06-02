using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace labparser.Model
{
    internal class LabShape
    {
        [JsonProperty("phoneLabels")]
        public List<PhoneLabel> PhoneLabels { get; set; }

        public LabShape()
        {
            PhoneLabels = new List<PhoneLabel>();
        }
    }
}
