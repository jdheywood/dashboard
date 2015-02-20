using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class EventsQueryResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("events")]
        public IEnumerable<Event> Events { get; set; }
    }
}
