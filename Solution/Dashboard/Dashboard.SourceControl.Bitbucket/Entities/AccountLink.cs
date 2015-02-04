using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class AccountLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
