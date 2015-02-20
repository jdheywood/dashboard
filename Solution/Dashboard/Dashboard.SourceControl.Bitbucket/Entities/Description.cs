using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class Description
    {
        [JsonProperty("total_commits")]
        public int TotalCommits { get; set; }

        [JsonProperty("commits")]
        public IEnumerable<Commit> Commits { get; set; }
    }
}
