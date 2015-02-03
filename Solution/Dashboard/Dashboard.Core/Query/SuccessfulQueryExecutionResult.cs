using Dashboard.Core.Contracts;

namespace Dashboard.Core.Query
{
    public class SuccessfulQueryExecutionResult<T> : QueryExecutionResult<T>
    {
        public SuccessfulQueryExecutionResult(T result)
            : base(result)
        {
        }

        public override IExecutionStatus Status
        {
            get { return ExecutionStatus.Ok; }
        }
    }
}