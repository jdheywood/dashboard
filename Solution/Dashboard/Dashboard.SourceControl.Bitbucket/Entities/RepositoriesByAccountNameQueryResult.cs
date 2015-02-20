using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class RepositoriesByAccountNameQueryResult
    {
        [JsonProperty("pagelen")]
        public int PageLength { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("values")]
        public IEnumerable<Repository> Repositories { get; set; }
    }
}
