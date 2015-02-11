using System;
using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Entities;

namespace Dashboard.SourceControl.Bitbucket.Clients
{
    public class BitbucketClient : IBitbucketClient
    {
        private readonly IBitbucketConfigurationFactory bitbucketConfigurationFactory;
        private readonly IHttpClient httpClient;

        public BitbucketClient(IBitbucketConfigurationFactory bitbucketConfigurationFactory, IHttpClient httpClient)
        {
            this.bitbucketConfigurationFactory = bitbucketConfigurationFactory;
            this.httpClient = httpClient;
        }

        public AccountByUserNameQueryResult GetUserAccount(string userName)
        {
            var configuration = bitbucketConfigurationFactory.Create();

            var jsonResult = httpClient.GetJson(String.Format("{0}/{1}", configuration.BitbucketApiEndPointUsers, userName), configuration.BitbucketApiTimeoutSeconds);

            return jsonResult.FromJson<AccountByUserNameQueryResult>();
        }

        public AccountByTeamNameQueryResult GetTeamAccount(string teamName)
        {
            var configuration = bitbucketConfigurationFactory.Create();

            var jsonResult = httpClient.GetJson(configuration.BitbucketApiEndPointTeams, configuration.BitbucketApiTimeoutSeconds);

            return jsonResult.FromJson<AccountByTeamNameQueryResult>();
        }

        public string GetRepository(string repositoryName)
        {
            // TODO wire up to return httpClient.GetJson(...)

            throw new NotImplementedException();
        }
    }
}
