using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Exceptions;
using SqlQueries.Statements;

namespace SqlQueries.Test.Parts
{
    [TestClass]
    public class QueryBuilderCollectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void BuildersGet()
        {
            QueryBuilders.Builders.Get(typeof(SqlConnection), typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void BuildersGet2()
        {

            QueryBuilders qb =  QueryBuilders.Builders.Get(typeof(SqlConnection));

            StatementBuilder sb = qb.Get(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void BuildersGet3()
        {
            StatementBuilder qb = QueryBuilders.Builders.Get(null, null);

        }
    }
}