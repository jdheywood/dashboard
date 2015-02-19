using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class AccountByTeamNameQueryResult
    {
        [JsonProperty("uuid")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("links")]
        public Dictionary<string, AccountLink> Links { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
