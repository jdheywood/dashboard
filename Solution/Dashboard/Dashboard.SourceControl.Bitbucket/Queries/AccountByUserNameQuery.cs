using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Entities;
using Dashboard.SourceControl.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Bitbucket.Queries
{
    public class AccountByUserNameQuery : IAccountByUserNameQuery
    {
        private readonly IBitbucketClient bitbucketClient;
        private readonly IMapper mapper;

        public AccountByUserNameQuery(IBitbucketClient bitbucketClient, IMapper mapper)
        {
            this.bitbucketClient = bitbucketClient;
            this.mapper = mapper;
        }

        public Account Execute(string userName)
        {
            var jsonResult = bitbucketClient.GetUserJson(userName);

            var result = jsonResult.FromJson<AccountByUserNameQueryResult>();

            var queryResult = mapper.Map<Account>(result); // TODO need to set up/complete the mappings

            return queryResult;
        }
    }
}
