using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class Repository
    {
        // TODO identify which fields can be turned into enums

        [JsonProperty("scm")]
        public string SourceControlManager { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("links")]
        public Dictionary<string, AccountLink> Links { get; set; } // TODO replace with a RepositoryLinks object as per returned json (clone array in this breaks deserialisation to AccountLinks)

        [JsonProperty("fork_policy")]
        public string ForkPolicy { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("created_on")]
        public DateTime Created { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("has_issues")]
        public string HasIssues { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("updated_on")]
        public DateTime? UpdatedOn { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
        
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}
