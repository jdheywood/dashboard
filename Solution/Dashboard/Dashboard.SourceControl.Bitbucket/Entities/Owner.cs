using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class Owner
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("uuid")]
        public string Id { get; set; }

        [JsonProperty("links")]
        public Dictionary<string, AccountLink> Links { get; set; }
    }
}
