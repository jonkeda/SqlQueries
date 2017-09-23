using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Statements;

namespace SqlQueries.Test.Exceptions
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
