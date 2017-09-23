using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SqlQueries.Statements
{
    [Serializable]
    public class QueryBuilderNotImplementedForSqliteException : QueryBuilderNotImplementedException
    {
        public QueryBuilderNotImplementedForSqliteException()
        {
        }

        public QueryBuilderNotImplementedForSqliteException(string message) : base(message)
        {
        }

        public QueryBuilderNotImplementedForSqliteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryBuilderNotImplementedForSqliteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}