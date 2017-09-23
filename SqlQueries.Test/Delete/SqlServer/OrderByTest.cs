using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Statements;

namespace SqlQueries.Test.Delete.SqlServer
{
    [TestClass]
    public class OrderByTest : OrderByBaseTest
    {
        public OrderByTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "DELETE FROM [TestDatabase].[Dbo].[Customers] ORDER BY [CustomerName], [ContactName] DESC";

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public override void TestExpectedSql()
        {
            base.TestExpectedSql();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void ConstructorOrderBy()
        {
            base.ConstructorOrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void Constructor2OrderBy()
        {
            base.Constructor2OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void Fluent2OrderBy()
        {
            base.Fluent2OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void FluentOrderBy()
        {
            base.FluentOrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void Fluent3OrderBy()
        {
            base.Fluent3OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void Properties1OrderBy()
        {
            base.Properties1OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void Properties2OrderBy()
        {
            base.Properties2OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqlServerException))]
        public override void Properties3OrderBy()
        {
            base.Properties3OrderBy();
        }
    }
}