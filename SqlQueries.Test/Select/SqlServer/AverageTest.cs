using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class AverageTest : AverageBaseTest
    {
        public AverageTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT AVG([TotalAmount]), AVG([c].[TotalAmount]), AVG([c].[Price]) AS [p] FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}