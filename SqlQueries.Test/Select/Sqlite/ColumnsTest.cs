using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class ColumnsTest : ColumnsBaseTest
    {
        public ColumnsTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT [Price], [c].[Price], [c].[Price] AS [p], [Price] AS [p] FROM [Customers] AS [c]";

    }
}