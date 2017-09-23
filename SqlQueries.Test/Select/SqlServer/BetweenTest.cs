using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class BetweenTest : BetweenBaseTest
    {
        public BetweenTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [Country] BETWEEN @p0 AND @p1";
    }
}