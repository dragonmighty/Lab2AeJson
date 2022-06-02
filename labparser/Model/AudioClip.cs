using Newtonsoft.Json;

namespace labparser.Model
{
    public class AudioClip
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("startSeconds")]
        public double StartSeconds { get; set; }
        [JsonProperty("endSeconds")]
        public double EndSeconds { get; set; }
        [JsonProperty("inPointSeconds")]
        public double InPointSeconds { get; set; }
        [JsonProperty("endPointSeconds")]
        public double EndPointSeconds { get; set; }
        [JsonProperty("duration")]
        public double Duration { get; set; }

        public AudioClip(string Name, double StartSeconds, double EndSeconds, double InPointSeconds, double EndPointSeconds, double Duration)
        {
            this.Name = Name;
            this.StartSeconds = StartSeconds;
            this.EndSeconds = EndSeconds;
            this.InPointSeconds = InPointSeconds;
            this.EndPointSeconds = EndPointSeconds;
            this.Duration = Duration;
        }
    }
}