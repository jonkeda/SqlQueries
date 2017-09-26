using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Exceptions
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
