using System;

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
    }
}