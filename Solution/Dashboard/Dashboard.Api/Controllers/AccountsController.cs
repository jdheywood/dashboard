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
    public class AccountsController : ApiController
    {
        private readonly IAccountByUserNameQuery accountByUserNameQuery;
        private readonly IAccountByTeamNameQuery accountByTeamNameQuery;
        private readonly IHttpActionResultFactory httpActionResultFactory;
        private readonly IMapper mapper;

        public AccountsController(IAccountByUserNameQuery accountByUserNameQuery,
            IAccountByTeamNameQuery accountByTeamNameQuery,
            IHttpActionResultFactory httpActionResultFactory,
            IMapper mapper)
        {
            this.accountByUserNameQuery = accountByUserNameQuery;
            this.accountByTeamNameQuery = accountByTeamNameQuery;
            this.httpActionResultFactory = httpActionResultFactory;
            this.mapper = mapper;
        }

        [Route("accounts")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("accounts/{accountName}")]
        [HttpGet]
        public IHttpActionResult Get(string accountName)
        {
            try
            {
                var accountResult = accountByUserNameQuery.Execute(accountName);

                if (!accountResult.IsSuccessful)
                {
                    accountResult = accountByTeamNameQuery.Execute(accountName);
                }

                return !accountResult.IsSuccessful
                    ? httpActionResultFactory.Create(accountResult, Request)
                    : Ok(mapper.Map<AccountResponseDto>(accountResult.Result));
            }
            catch (Exception ex)
            {
                // TODO Introduce logging for this
            }

            return new NoContent(Request);
        }
    }
}
