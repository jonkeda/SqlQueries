using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class MinimumTest : MinimumBaseTest
    {
        public MinimumTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT MIN([TotalAmount]), MIN([c].[TotalAmount]), MIN([c].[Price]) AS [p] FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}