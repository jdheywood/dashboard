using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Bitbucket.Configuration;
using Dashboard.SourceControl.Bitbucket.Contracts;

namespace Dashboard.SourceControl.Bitbucket.Factories
{
    public class BitbucketConfigurationFactory : IBitbucketConfigurationFactory
    {
        private const string BitbucketPassword = "Bitbucket.Password";
        private const string BitbucketUsername = "Bitbucket.Username";
        private const string BitbucketTeamName = "Bitbucket.TeamName";
        private const string BitbucketApiEndPointUsers = "Bitbucket.API.Endpoint.Ussers"; 
        private const string BitbucketApiEndPointTeams = "Bitbucket.API.Endpoint.Teams";

        private readonly IConfigurationRepository configurationRepository;

        public BitbucketConfigurationFactory(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        public IBitbucketConfiguration Create()
        {
            return new BitbucketConfiguration()
            {
                BitbucketPassword = configurationRepository.GetSimpleSetting<string>(BitbucketPassword),
                BitbucketUsername = configurationRepository.GetSimpleSetting<string>(BitbucketUsername),
                BitbucketTeamName = configurationRepository.GetSimpleSetting<string>(BitbucketTeamName),
                BitbucketApiEndPointUsers = configurationRepository.GetSimpleSetting<string>(BitbucketApiEndPointUsers),
                BitbucketApiEndPointTeams = configurationRepository.GetSimpleSetting<string>(BitbucketApiEndPointTeams)
            };
        }
    }
}
