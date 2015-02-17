using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Dashboard.Core.ActionResult;
using Dashboard.Core.Contracts;
using Dashboard.Core.Models;

namespace Dashboard.Core.Factories
{
    public class HttpActionResultFactory : IHttpActionResultFactory
    {
        private readonly IMapper mapper;

        public HttpActionResultFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IHttpActionResult Create(IExecutionResult result, HttpRequestMessage request)
        {
            switch (result.Status.Status)
            {
                case ExecutionStatusCode.NotFound:
                    return new NotFoundWithContent(request, mapper.Map<List<ErrorDto>>(result.Errors));
                case ExecutionStatusCode.Error:
                    return new ErrorWithContent(request, mapper.Map<List<ErrorDto>>(result.Errors));
                case ExecutionStatusCode.Exception:
                    return new InternalServerErrorResult(request);
                default:
                    return new OkResult(request);
            }
        }
    }
}
