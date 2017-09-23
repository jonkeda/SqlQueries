using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class AnyTest : AnyBaseTest
    {
        public AnyTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers] WHERE [Country] = ANY (SELECT [Country] FROM [Suppliers])";

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestExpectedSqls()
        {
            // not implemented in sqlite
            base.TestExpectedSqls();
        }

    }
}