using System;
using System.Runtime.Serialization;

namespace SqlQueries.Statements
{
    [Serializable]
    public class QueryBuilderNotImplementedException : Exception
    {
        public QueryBuilderNotImplementedException()
        {
        }

        public QueryBuilderNotImplementedException(string message) : base(message)
        {
        }

        public QueryBuilderNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueryBuilderNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}