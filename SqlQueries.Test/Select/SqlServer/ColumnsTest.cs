using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ColumnsTest : ColumnsBaseTest
    {
        public ColumnsTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string ColumnsExpected { get; } = "SELECT [b], [a].[b], [a].[b] AS [c], [b] AS [c] FROM [TestDatabase].[Dbo].[Customers] AS [c]";

    }
}