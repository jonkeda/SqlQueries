using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ColumnStarTest : ColumnStarBaseTest
    {
        public ColumnStarTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string ColumnStarExpected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers]";

        public override string ColumnTableStarExpected { get; } = "SELECT [c].* FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}