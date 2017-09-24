using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Union.Sqlite
{
    [TestClass]
    public class UnionTest : UnionBaseTest
    {
        public UnionTest() : base(typeof(SQLiteConnection))
        {
        }
        public override string Expected { get; } = "SELECT [City] FROM [Customers] UNION SELECT [City] FROM [Suppliers]";
    }
}
