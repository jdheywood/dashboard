namespace Dashboard.SourceControl.Bitbucket.Contracts
{
    public interface IBitbucketConfiguration
    {
        string BitbucketConsumerKey { get; }

        string BitbucketConsumerSecret { get; }

        string BitbucketPassword { get; }

        string BitbucketUsername { get; }

        string BitbucketTeamName { get; }

        int BitbucketApiTimeoutSeconds { get; }

        string BitbucketApiEndPointUsers { get; }

        string BitbucketApiEndPointTeams { get; }

        string BitbucketApiEndPointRepositories { get; }

        string BitbucketApiEndPointTokenRequest { get; }
    }
}
