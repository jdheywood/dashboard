using Dashboard.SourceControl.Bitbucket.Contracts;

namespace Dashboard.SourceControl.Bitbucket.Configuration
{
    public class BitbucketConfiguration : IBitbucketConfiguration
    {
        public string BitbucketConsumerKey { get; set; }

        public string BitbucketConsumerSecret { get; set; }

        public string BitbucketPassword { get; set; }

        public string BitbucketUsername { get; set; }

        public string BitbucketTeamName { get; set; }

        public int BitbucketApiTimeoutSeconds { get; set; }

        public string BitbucketApiEndPointUsers { get; set; }

        public string BitbucketApiEndPointTeams { get; set; }
        
        public string BitbucketApiEndPointRepositories { get; set; }

        public string BitbucketApiEndPointTokenRequest { get; set; }
    }
}
