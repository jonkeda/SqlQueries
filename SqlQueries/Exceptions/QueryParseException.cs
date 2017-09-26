using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Srt2.SqlQueries.Exceptions
{
    [Serializable]
    public class QueryParseException : Exception
    {
        public QueryParseException()
        {
        }

        public QueryParseException(string message) : base(message)
        {
        }

        public QueryParseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}