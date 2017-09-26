using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Srt2.SqlQueries.Builders
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

        [ExcludeFromCodeCoverage]
        protected QueryBuilderNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}