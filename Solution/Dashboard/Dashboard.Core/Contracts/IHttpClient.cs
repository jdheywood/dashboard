using System;
using System.Collections.Generic;

namespace Dashboard.Core.Contracts
{
    public interface IHttpClient
    {
        string GetJson(string url, int timeoutInSeconds, IEnumerable<Tuple<string, string>> additionalHeaders);

        string PostJson(string url, string json, int timeoutInSeconds, IEnumerable<Tuple<string, string>> additionalHeaders);
    }
}
