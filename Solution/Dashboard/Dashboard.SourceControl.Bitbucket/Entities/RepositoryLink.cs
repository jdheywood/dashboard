using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class RepositoryLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
