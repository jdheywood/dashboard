using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class Commit
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
