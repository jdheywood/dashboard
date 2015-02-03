using Dashboard.SourceControl.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Bitbucket.Queries
{
    public class AccountByUserNameQuery : IAccountByUserNameQuery
    {
        public Account Execute(string userName)
        {
            // TODO - use factory to get config to then form request to bitbucket api and return and then map json to domain entity
            return null;
        }
    }
}
