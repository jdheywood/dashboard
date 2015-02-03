namespace Dashboard.Core.Contracts
{
    public interface IQueryExecutionResult<out TResult> : IExecutionResult
    {
        TResult Result { get; }
    }
}