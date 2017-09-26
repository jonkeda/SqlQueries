using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Delete.Sqlite
{
    [TestClass]
    public class OrderByTest : OrderByBaseTest
    {
        public OrderByTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "DELETE FROM [Customers] ORDER BY [CustomerName], [ContactName] DESC LIMIT (10)";

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestExpectedSql()
        {
            base.TestExpectedSql();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void ConstructorOrderBy()
        {
            base.ConstructorOrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Constructor2OrderBy()
        {
            base.Constructor2OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Fluent2OrderBy()
        {
            base.Fluent2OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentOrderBy()
        {
            base.FluentOrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Fluent3OrderBy()
        {
            base.Fluent3OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Properties1OrderBy()
        {
            base.Properties1OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Properties2OrderBy()
        {
            base.Properties2OrderBy();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Properties3OrderBy()
        {
            base.Properties3OrderBy();
        }
    }
}