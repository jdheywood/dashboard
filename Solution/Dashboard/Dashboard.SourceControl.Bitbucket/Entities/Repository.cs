using System;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("website")]
        public string WebSite { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("resource_uri")]
        public string ResourceUri { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("scm")]
        public string SourceControlManager { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("utc_created_on")]
        public DateTime CreatedOnUtc { get; set; }

        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("utc_last_updated")]
        public DateTime? LastUpdatedUtc { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("is_fork")]
        public bool IsFork { get; set; }

        //"fork_of": null,
        [JsonProperty("fork_of")]
        public string ForkOf { get; set; }

        [JsonProperty("no_forks")]
        public bool NoForks { get; set; }

        [JsonProperty("no_public_forks")]
        public bool NoPublicForks { get; set; }

        [JsonProperty("is_mq")]
        public bool IsMq { get; set; }

        //"mq_of": null,
        [JsonProperty("mq_of")]
        public string MqOf { get; set; }

        [JsonProperty("email_mailinglist")]
        public string EmailMailingList { get; set; }

        [JsonProperty("email_writers")]
        public bool EmailWriters { get; set; }

        [JsonProperty("read_only")]
        public bool ReadOnly { get; set; }
        
        //"state": "available",
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("has_issues")]
        public string HasIssues { get; set; }

        //"creator": null,
        [JsonProperty("creator")]
        public string Creater { get; set; }
    }
}
