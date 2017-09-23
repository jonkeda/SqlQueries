using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SqlQueries.Statements
{
    [Serializable]
    public class QueryBuilderNotImplementedForSqlServerException : QueryBuilderNotImplementedException
    {
        public QueryBuilderNotImplementedForSqlServerException()
        {
        }

        public QueryBuilderNotImplementedForSqlServerException(string message) : base(message)
        {
        }

        public QueryBuilderNotImplementedForSqlServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryBuilderNotImplementedForSqlServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}