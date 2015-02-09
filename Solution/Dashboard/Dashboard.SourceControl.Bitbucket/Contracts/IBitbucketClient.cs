namespace Dashboard.SourceControl.Bitbucket.Contracts
{
    public interface IBitbucketClient
    {
        string GetUserJson(string userName);

        string GetTeamJson(string teamName);

        string GetRepositoryJson(string repositoryName);
    }
}
