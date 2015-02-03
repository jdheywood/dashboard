namespace Dashboard.SourceControl.Bitbucket.Contracts
{
    public interface IBitbucketConfiguration
    {
        string BitbucketPassword { get; }

        string BitbucketUsername { get; }

        string BitbucketTeamName { get; }

        string BitbucketApiEndPointUsers { get; }

        string BitbucketApiEndPointTeams { get; }
    }
}
