using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Dashboard.Core.Models;

namespace Dashboard.Core.ActionResult
{
    public class ErrorWithContent : ResultWithContent<List<ErrorDto>>
    {
        public ErrorWithContent(HttpRequestMessage request, List<ErrorDto> content)
            : base(request, content)
        {
        }

        protected override HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.BadRequest; }
        }
    }
}