using System;
using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Bitbucket.Contracts;

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


        public string GetUserJson(string userName)
        {
            var configuration = bitbucketConfigurationFactory.Create();

            return httpClient.GetJson(configuration.BitbucketApiEndPointUsers, configuration.BitbucketApiTimeoutSeconds);
        }

        public string GetTeamJson(string teamName)
        {
            var configuration = bitbucketConfigurationFactory.Create();

            return httpClient.GetJson(configuration.BitbucketApiEndPointTeams, configuration.BitbucketApiTimeoutSeconds);
        }

        public string GetRepositoryJson(string repositoryName)
        {
            // TODO wire up to return httpClient.GetJson(...)

            throw new NotImplementedException();
        }
    }
}
