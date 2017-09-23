using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class ColumnStarTest : ColumnStarBaseTest
    {
        public ColumnStarTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers]";

        public override string StarExpected { get; } = "SELECT [c].* FROM [Customers] AS [c]";
    }
}