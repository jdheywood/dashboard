using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
using Dashboard.Core.Query;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Bitbucket.Queries
{
    public class AccountByTeamNameQuery : IAccountByTeamNameQuery
    {
        private readonly IBitbucketClient bitbucketClient;
        private readonly IMapper mapper;

        public AccountByTeamNameQuery(IBitbucketClient bitbucketClient, IMapper mapper)
        {
            this.bitbucketClient = bitbucketClient;
            this.mapper = mapper;
        }
        
        public IQueryExecutionResult<Account> Execute(string teamName)
        {
            var queryResult = bitbucketClient.GetTeamAccount(teamName);

            var mappedAccount = mapper.Map<Account>(queryResult);

            return mappedAccount == null
                ? (IQueryExecutionResult<Account>)"Problem retrieving account by team name".ToNotFoundQueryExecutionResult<Account>()
                : new SuccessfulQueryExecutionResult<Account>(mappedAccount);
        }
    }
}
