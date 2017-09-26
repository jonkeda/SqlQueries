using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class OrderByTest : OrderByBaseTest
    {
        public OrderByTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] ORDER BY [CustomerName], [ContactName] DESC";

    }
}