using System;
using System.CodeDom;
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
            throw new NotImplementedException();
        }

        public string GetTeamJson(string teamName)
        {
            throw new NotImplementedException();
        }

        public string GetRepositoryJson(string repositoryName)
        {
            throw new NotImplementedException();
        }
    }
}
