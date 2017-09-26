using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Delete.Sqlite
{
    [TestClass]
    public class DeleteTest : DeleteBaseTest
    {
        public DeleteTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "DELETE FROM [Customers]";

        public override string TopExpected { get; } = "DELETE FROM [Customers] LIMIT (10)";

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestTopExpectedSql()
        {
            base.TestTopExpectedSql();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void ConstructorTop()
        {
            // todo: Delete Top not implemented for Sqlite
            base.ConstructorTop();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentTop()
        {
            // todo: Delete Top not implemented for Sqlite
            base.FluentTop();
        }
    }
}
