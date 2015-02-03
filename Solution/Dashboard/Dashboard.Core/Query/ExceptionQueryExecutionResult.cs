using System.Collections.Generic;
using Dashboard.Core.Contracts;

namespace Dashboard.Core.Query
{
    public class ExceptionQueryExecutionResult<T> : QueryExecutionResult<T>
    {
        public ExceptionQueryExecutionResult(List<Error> errors = null)
            : base(default(T), errors)
        {
        }

        public override IExecutionStatus Status
        {
            get { return ExecutionStatus.Exception; }
        }
    }
}