namespace Dashboard.SourceControl.Bitbucket.Contracts
{
    public interface IBitbucketConfiguration
    {
        string BitbucketPassword { get; }

        string BitbucketUsername { get; }

        string BitbucketTeamName { get; }

        int BitbucketApiTimeoutSeconds { get; }

        string BitbucketApiEndPointUsers { get; }

        string BitbucketApiEndPointTeams { get; }
    }
}
