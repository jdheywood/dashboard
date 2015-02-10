using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Contracts
{
    public interface IAccountByUserNameQuery
    {
        IQueryExecutionResult<Account> Execute(string userName);
    }
}
