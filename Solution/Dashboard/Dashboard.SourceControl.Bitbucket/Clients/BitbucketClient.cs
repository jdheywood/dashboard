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
            try
            {
                var configuration = bitbucketConfigurationFactory.Create();

                var jsonResult = httpClient.GetJson(String.Format("{0}/{1}", configuration.BitbucketApiEndPointUsers, userName), configuration.BitbucketApiTimeoutSeconds);

                return jsonResult.FromJson<AccountByUserNameQueryResult>();
            }
            catch (Exception ex)
            {
                // TODO Add logging
            }
            
            return null;
        }

        public AccountByTeamNameQueryResult GetTeamAccount(string teamName)
        {
            try
            {
                var configuration = bitbucketConfigurationFactory.Create();

                var jsonResult = httpClient.GetJson(String.Format("{0}/{1}", configuration.BitbucketApiEndPointTeams, teamName), configuration.BitbucketApiTimeoutSeconds);

                return jsonResult.FromJson<AccountByTeamNameQueryResult>();
            }
            catch (Exception)
            {
                // TODO Add logging
            }
            
            return null;
        }

        public string GetRepository(string repositoryName)
        {
            // TODO wire up to return httpClient.GetJson(...)

            throw new NotImplementedException();
        }
    }
}
