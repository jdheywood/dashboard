using Dashboard.Core.Extensions;
using Dashboard.Core.Web;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Entities;
using Dashboard.SourceControl.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Bitbucket.Queries
{
    public class AccountByUserNameQuery : IAccountByUserNameQuery
    {
        private IBitbucketConfigurationFactory bitbucketConfigurationFactory;
        
        private readonly HttpClient httpClient;

        public AccountByUserNameQuery()
        {
            httpClient = new HttpClient();
        }

        public Account Execute(string userName)
        {
            // TODO - use factory to get config to then form request to bitbucket api and return and then map json to domain entity

            var configuration = bitbucketConfigurationFactory.Create();

            var jsonResult = httpClient.GetJson(configuration.BitbucketApiEndPointUsers, configuration.BitbucketApiTimeoutSeconds);

            var result = jsonResult.FromJson<AccountByUserNameQueryResult>();

            var queryResult = AutoMapper.Mapper.Map<Account>(result);

            return queryResult;
        }
    }
}
