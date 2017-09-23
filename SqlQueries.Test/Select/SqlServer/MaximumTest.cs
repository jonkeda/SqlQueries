using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class MaximumTest : MaximumBaseTest
    {
        public MaximumTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT MAX([TotalAmount]), MAX([c].[TotalAmount]), MAX([c].[Price]) AS [p] FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}