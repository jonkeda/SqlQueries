using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ColumnsTest : ColumnsBaseTest
    {
        public ColumnsTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT [Price], [c].[Price], [c].[Price] AS [p], [Price] AS [p] FROM [TestDatabase].[Dbo].[Customers] AS [c]";

    }
}