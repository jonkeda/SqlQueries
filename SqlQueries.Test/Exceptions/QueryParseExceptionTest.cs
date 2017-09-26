using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Exceptions
{
    [TestClass]
    public  class QueryParseExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(QueryParseException))]
        public void Constructor1()
        {
            throw new QueryParseException();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryParseException))]
        public void Constructor2()
        {
            throw new QueryParseException("");
        }

        [TestMethod]
        [ExpectedException(typeof(QueryParseException))]
        public void Constructor3()
        {
            throw new QueryParseException("", new Exception());
        }
    }
}
