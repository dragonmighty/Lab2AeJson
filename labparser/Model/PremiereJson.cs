using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace labparser.Model
{
    internal class PremiereJson
    {
        [JsonProperty("audioClips")]
        public List<AudioClip> AudioClips { get; set; }
        [JsonProperty("targetClipStartsAt")]
        public double TargetClipStartsAt { get; set; }
        [JsonProperty("targetClipEndsAt")]
        public double TargetClipEndsAt { get; set; }

        public PremiereJson()
        {
            AudioClips = new List<AudioClip>();
            TargetClipStartsAt = 0;
        }
    }
}
