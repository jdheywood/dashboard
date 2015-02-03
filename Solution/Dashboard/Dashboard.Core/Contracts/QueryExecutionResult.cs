using System.Collections.Generic;

namespace Dashboard.Core.Contracts
{
    public abstract class QueryExecutionResult<T> : ExecutionResult, IQueryExecutionResult<T>
    {
        private readonly T result;

        protected QueryExecutionResult(T result, List<Error> errors = null)
            : base(errors)
        {
            this.result = result;
        }

        public T Result
        {
            get { return result; }
        }
    }
}