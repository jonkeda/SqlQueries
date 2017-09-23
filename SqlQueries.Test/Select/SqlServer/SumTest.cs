using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class SumTest : SumBaseTest
    {
        public SumTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT SUM([TotalAmount]), SUM([c].[TotalAmount]), SUM([c].[Price]) AS [p] FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}