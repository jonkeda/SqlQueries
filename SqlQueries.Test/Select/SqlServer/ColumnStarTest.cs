using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ColumnStarTest : ColumnStarBaseTest
    {
        public ColumnStarTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers]";

        public override string StarExpected { get; } = "SELECT [c].* FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}