using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Delete.SqlServer;

namespace SqlQueries.Test.Delete.Sqlite
{
    [TestClass]
    public class DeleteTest : DeleteBaseTest
    {
        public DeleteTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string DeleteExpected { get; } = "DELETE FROM [Customers]";

        public override string DeleteTopExpected { get; } = "DELETE FROM [TestDatabase].[Dbo].[Customers] LIMIT 10";

        [TestMethod]
        public override void ConstructorTop()
        {
            // todo: Delete Top not implemented for Sqlite
        }

        [TestMethod]
        public override void FluentTop()
        {
            // todo: Delete Top not implemented for Sqlite
        }
    }
}
