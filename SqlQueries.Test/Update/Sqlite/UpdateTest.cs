using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.Update.Sqlite
{
    [TestClass]
    public class UpdateTest : UpdateBaseTest
    {
        public UpdateTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "UPDATE [Customers] SET [CustomerName] = @p0 ";

        public override string TopExpected { get; } = "UPDATE [Customers] SET [CustomerName] = @p0 ";

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
