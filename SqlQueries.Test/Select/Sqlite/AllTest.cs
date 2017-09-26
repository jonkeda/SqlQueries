using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class AllTest : AllBaseTest
    {
        public AllTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } =
            "SELECT * FROM [Customers] WHERE [Country] = ALL (SELECT [Country] FROM [Suppliers])";

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestExpectedSql()
        {
            // not implemented in sqlite
            base.TestExpectedSql();
        }
    }
}