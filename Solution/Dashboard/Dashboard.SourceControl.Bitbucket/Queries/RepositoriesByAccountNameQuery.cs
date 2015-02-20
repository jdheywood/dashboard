using System.Collections.Generic;
using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
using Dashboard.Core.Query;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Bitbucket.Queries
{
    public class RepositoriesByAccountNameQuery : IRepositoriesByAccountNameQuery
    {
        private readonly IBitbucketClient bitbucketClient;
        private readonly IMapper mapper;

        public RepositoriesByAccountNameQuery(IBitbucketClient bitbucketClient, IMapper mapper)
        {
            this.bitbucketClient = bitbucketClient;
            this.mapper = mapper;
        }

        public IQueryExecutionResult<IEnumerable<Repository>> Execute(string accountName)
        {
            var queryResult = bitbucketClient.GetAccountRepositories(accountName);

            var mappedRepositories = mapper.Map<IEnumerable<Repository>>(queryResult);

            return mappedRepositories == null
                ? (IQueryExecutionResult<IEnumerable<Repository>>)"Problem retrieving repositories for account name".ToNotFoundQueryExecutionResult<IEnumerable<Repository>>()
                : new SuccessfulQueryExecutionResult<IEnumerable<Repository>>(mappedRepositories);
        }
    }
}
