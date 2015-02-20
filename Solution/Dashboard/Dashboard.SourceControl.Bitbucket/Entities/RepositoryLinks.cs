using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class RepositoryLinks
    {
        [JsonProperty("watchers")]
        public RepositoryLink Watchers { get; set; }

        [JsonProperty("commits")]
        public RepositoryLink Commits { get; set; }

        [JsonProperty("self")]
        public RepositoryLink Self { get; set; }

        [JsonProperty("html")]
        public RepositoryLink Html { get; set; }

        [JsonProperty("avatar")]
        public RepositoryLink Avatar { get; set; }

        [JsonProperty("forks")]
        public RepositoryLink Forks { get; set; }

        [JsonProperty("clone")]
        public IEnumerable<RepositoryLink> Clone { get; set; }

        [JsonProperty("pullrequests")]
        public RepositoryLink PullRequests { get; set; }
    }
}
