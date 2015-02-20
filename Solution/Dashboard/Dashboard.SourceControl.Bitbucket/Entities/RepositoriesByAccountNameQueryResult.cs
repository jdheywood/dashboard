using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class RepositoriesByAccountNameQueryResult
    {
        [JsonProperty("repositories")]
        public IEnumerable<Repository> Repositories { get; set; }
    }
}
