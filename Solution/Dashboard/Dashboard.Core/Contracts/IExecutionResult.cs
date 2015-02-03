using System.Collections.Generic;

namespace Dashboard.Core.Contracts
{
    public interface IExecutionResult
    {
        bool IsSuccessful { get; }

        IExecutionStatus Status { get; }

        List<Error> Errors { get; } 
    }
}