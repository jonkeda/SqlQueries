using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders;

namespace Srt2.SqlQueries.Test.Exceptions
{
    [TestClass]
    public  class QueryBuilderNotImplementedExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedException))]
        public void Constructor1()
        {
            throw new QueryBuilderNotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedException))]
        public void Constructor2()
        {
            throw new QueryBuilderNotImplementedException("");
        }
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedException))]
        public void Constructor3()
        {
            throw new QueryBuilderNotImplementedException("", new Exception());
        }
    }
}
