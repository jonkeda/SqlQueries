using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SqlQueries.Statements
{
    [Serializable]
    public class QueryBuilderException : Exception
    {
        public QueryBuilderException()
        {
        }

        public QueryBuilderException(string message) : base(message)
        {
        }

        public QueryBuilderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryBuilderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}