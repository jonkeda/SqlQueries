using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class TopTest : TopBaseTest
    {
        public TopTest() : base(typeof(SQLiteConnection))
        {
        }

        protected override string Expected { get; } = "SELECT * FROM [Customers] LIMIT (10)";

        protected override string PercentageExpected { get; } = "SELECT * FROM [Customers] LIMIT (10) PERCENTAGE";

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentTopPercentage()
        {
            // not implemented in sqlite
            base.FluentTopPercentage();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void PropertiesTopPercentage()
        {
            // not implemented in sqlite
            base.PropertiesTopPercentage();
        }

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestPercentageExpectedSql()
        {
            base.TestPercentageExpectedSql();
        }
    }
}
