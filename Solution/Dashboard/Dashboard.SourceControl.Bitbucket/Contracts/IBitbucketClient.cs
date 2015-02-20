﻿using Dashboard.SourceControl.Bitbucket.Entities;

namespace Dashboard.SourceControl.Bitbucket.Contracts
{
    public interface IBitbucketClient
    {
        AccountByUserNameQueryResult GetUserAccount(string userName);
        
        AccountByTeamNameQueryResult GetTeamAccount(string teamName);

        RepositoriesByAccountNameQueryResult GetAccountRepositories(string accountName);
    }
}
