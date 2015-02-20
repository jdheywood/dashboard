using System;
using System.Collections.Generic;
using System.Web.Http;
using Dashboard.Api.Models;
using Dashboard.Core.ActionResult;
using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Contracts;

namespace Dashboard.Api.Controllers
{
    [RoutePrefix("api")]
    public class RepositoriesController : ApiController
    {
        private readonly IRepositoriesByAccountNameQuery repositoriesByAccountNameQuery;
        private readonly IHttpActionResultFactory httpActionResultFactory;
        private readonly IMapper mapper;

        public RepositoriesController(IRepositoriesByAccountNameQuery repositoriesByAccountNameQuery,
            IHttpActionResultFactory httpActionResultFactory,
            IMapper mapper)
        {
            this.repositoriesByAccountNameQuery = repositoriesByAccountNameQuery;
            this.httpActionResultFactory = httpActionResultFactory;
            this.mapper = mapper;
        }

        [Route("repositories/{accountName}")]
        [HttpGet]
        public IHttpActionResult Get(string accountName)
        {
            try
            {
                var repositoriesResult = repositoriesByAccountNameQuery.Execute(accountName);

                return !repositoriesResult.IsSuccessful
                    ? httpActionResultFactory.Create(repositoriesResult, Request)
                    : Ok(mapper.Map<IEnumerable<RepositoryResponseDto>>(repositoriesResult));
            }
            catch (Exception ex)
            {
                // TODO add logging   
            }

            return new NoContent(Request);
        }
    }
}
