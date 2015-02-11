using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Contracts
{
    public interface IAccountByTeamNameQuery
    {
        IQueryExecutionResult<Account> Execute(string teamName);
    }
}
