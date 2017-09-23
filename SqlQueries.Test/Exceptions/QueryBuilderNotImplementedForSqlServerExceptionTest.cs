using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Exceptions;

namespace SqlQueries.Test.Exceptions
{
    [TestClass]
    public  class QueryBuilderNotImplementedForSqlServerExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public void Constructor1()
        {
            throw new QueryBuilderNotImplementedForSqlServerException();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public void Constructor2()
        {
            throw new QueryBuilderNotImplementedForSqlServerException("");
        }
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public void Constructor3()
        {
            throw new QueryBuilderNotImplementedForSqlServerException("", new Exception());
        }
    }
}
