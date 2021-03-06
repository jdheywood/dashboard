﻿using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
using Dashboard.Core.Query;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Bitbucket.Queries
{
    public class AccountByUserNameQuery : IAccountByUserNameQuery
    {
        private readonly IBitbucketClient bitbucketClient;
        private readonly IMapper mapper;

        public AccountByUserNameQuery(IBitbucketClient bitbucketClient, IMapper mapper)
        {
            this.bitbucketClient = bitbucketClient;
            this.mapper = mapper;
        }

        public IQueryExecutionResult<Account> Execute(string userName)
        {
            var queryResult = bitbucketClient.GetUserAccount(userName);
            
            var mappedAccount = mapper.Map<Account>(queryResult); // TODO need to set up/complete the mappings

            return queryResult == null
                ? (IQueryExecutionResult<Account>)"Problem retrieving account by username".ToNotFoundQueryExecutionResult<Account>()
                : new SuccessfulQueryExecutionResult<Account>(mappedAccount);
        }
    }
}
