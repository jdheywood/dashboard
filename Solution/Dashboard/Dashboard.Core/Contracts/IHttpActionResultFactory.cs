using System.Net.Http;
using System.Web.Http;

namespace Dashboard.Core.Contracts
{
    public interface IHttpActionResultFactory
    {
        IHttpActionResult Create(IExecutionResult result, HttpRequestMessage request);
    }
}
