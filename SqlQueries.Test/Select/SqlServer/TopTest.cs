using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class TopTest : TopBaseTest
    {
        public TopTest() : base(typeof(SqlConnection))
        {
        }

        protected override string Expected { get; } = "SELECT TOP 10 * FROM [TestDatabase].[Dbo].[Customers]";

        protected override string PercentageExpected { get; } =
            "SELECT TOP 10 PERCENTAGE * FROM [TestDatabase].[Dbo].[Customers]";
    }
}
