using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Exceptions
{
    [TestClass]
    public  class QueryBuilderExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void Constructor1()
        {
            throw new QueryBuilderException();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void Constructor2()
        {
            throw new QueryBuilderException("");
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void Constructor3()
        {
            throw new QueryBuilderException("", new Exception());
        }
    }
}
