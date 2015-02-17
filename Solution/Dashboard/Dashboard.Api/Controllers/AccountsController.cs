using System.Collections.Generic;
using System.Web.Http;
using Dashboard.Api.Models;
using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Contracts;

namespace Dashboard.Api.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly IAccountByUserNameQuery accountByUserNameQuery;
        private readonly IHttpActionResultFactory httpActionResultFactory;
        private readonly IMapper mapper;

        public AccountsController(IAccountByUserNameQuery accountByUserNameQuery,
            IHttpActionResultFactory httpActionResultFactory,
            IMapper mapper)
        {
            this.accountByUserNameQuery = accountByUserNameQuery;
            this.httpActionResultFactory = httpActionResultFactory;
            this.mapper = mapper;
        }

        [Route("api/accounts")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/accounts/{accountName}")]
        [HttpGet]
        public IHttpActionResult Get(string accountName)
        {
            var accountResult = accountByUserNameQuery.Execute(accountName);

            return !accountResult.IsSuccessful
                ? httpActionResultFactory.Create(accountResult, Request)
                : Ok(mapper.Map<AccountResponseDto>(accountResult.Result));

        }
    }
}
