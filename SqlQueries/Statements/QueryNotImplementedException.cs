using System;
using System.Runtime.Serialization;

namespace SqlQueries.Statements
{
    [Serializable]
    public class QueryNotImplementedException : Exception
    {
        public QueryNotImplementedException()
        {
        }

        public QueryNotImplementedException(string message) : base(message)
        {
        }

        public QueryNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueryNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}