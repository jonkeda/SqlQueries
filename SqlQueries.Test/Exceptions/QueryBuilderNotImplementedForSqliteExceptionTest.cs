using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Exceptions
{
    [TestClass]
    public  class QueryBuilderNotImplementedForSqliteExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public void Constructor1()
        {
            throw new QueryBuilderNotImplementedForSqliteException();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public void Constructor2()
        {
            throw new QueryBuilderNotImplementedForSqliteException("");
        }
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public void Constructor3()
        {
            throw new QueryBuilderNotImplementedForSqliteException("", new Exception());
        }
    }
}
