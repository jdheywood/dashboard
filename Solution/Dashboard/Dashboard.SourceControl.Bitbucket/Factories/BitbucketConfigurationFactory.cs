using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Bitbucket.Configuration;
using Dashboard.SourceControl.Bitbucket.Contracts;

namespace Dashboard.SourceControl.Bitbucket.Factories
{
    public class BitbucketConfigurationFactory : IBitbucketConfigurationFactory
    {
        private const string BitbucketConsumerKey = "Bitbucket.Consumer.Key";
        private const string BitbucketConsumerSecret = "Bitbucket.Consumer.Secret";
        private const string BitbucketPassword = "Bitbucket.Password";
        private const string BitbucketUsername = "Bitbucket.Username";
        private const string BitbucketTeamName = "Bitbucket.TeamName";
        private const string BitbucketApiTimeoutSeconds = "Bitbucket.API.Timeout.Seconds";
        private const string BitbucketApiEndPointUsers = "Bitbucket.API.Endpoint.Users"; 
        private const string BitbucketApiEndPointTeams = "Bitbucket.API.Endpoint.Teams";
        private const string BitbucketApiEndPointRepositories = "Bitbucket.API.Endpoint.Repositories";
        private const string BitbucketApiEndPointTokenRequest = "Bitbucket.API.EndPoint.TokenRequest";

        private readonly IConfigurationRepository configurationRepository;

        public BitbucketConfigurationFactory(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        public IBitbucketConfiguration Create()
        {
            return new BitbucketConfiguration()
            {
                BitbucketConsumerKey = configurationRepository.GetSimpleSetting<string>(BitbucketConsumerKey),
                BitbucketConsumerSecret = configurationRepository.GetSimpleSetting<string>(BitbucketConsumerSecret),
                BitbucketPassword = configurationRepository.GetSimpleSetting<string>(BitbucketPassword),
                BitbucketUsername = configurationRepository.GetSimpleSetting<string>(BitbucketUsername),
                BitbucketTeamName = configurationRepository.GetSimpleSetting<string>(BitbucketTeamName),
                BitbucketApiTimeoutSeconds = configurationRepository.GetSimpleSetting<int>(BitbucketApiTimeoutSeconds),
                BitbucketApiEndPointUsers = configurationRepository.GetSimpleSetting<string>(BitbucketApiEndPointUsers),
                BitbucketApiEndPointTeams = configurationRepository.GetSimpleSetting<string>(BitbucketApiEndPointTeams),
                BitbucketApiEndPointRepositories = configurationRepository.GetSimpleSetting<string>(BitbucketApiEndPointRepositories)
            };
        }
    }
}
