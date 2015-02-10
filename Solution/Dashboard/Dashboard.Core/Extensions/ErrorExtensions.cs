using System.Collections.Generic;
using Dashboard.Core.Contracts;
using Dashboard.Core.Query;

namespace Dashboard.Core.Extensions
{
    public static class ErrorExtensions
    {
        public static ErrorQueryExecutionResult<T> ToErrorQueryExecutionResult<T>(this string errorMessage)
        {
            return new ErrorQueryExecutionResult<T>(new List<Error> { new Error { Message = errorMessage } });
        }

        public static NotFoundErrorQueryExecutionResult<T> ToNotFoundQueryExecutionResult<T>(this string errorMessage)
        {
            return new NotFoundErrorQueryExecutionResult<T>(new List<Error> { new Error { Message = errorMessage } });
        }
    }
}
