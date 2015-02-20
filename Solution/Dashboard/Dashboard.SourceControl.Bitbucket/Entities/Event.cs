using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class Event
    {
        [JsonProperty("node")]
        public string Node { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }

    }
}
