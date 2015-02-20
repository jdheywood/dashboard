using System.Collections.Generic;
using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Contracts
{
    public interface IRepositoriesByAccountNameQuery
    {
        IQueryExecutionResult<IEnumerable<Repository>> Execute(string accountName);
    }
}
