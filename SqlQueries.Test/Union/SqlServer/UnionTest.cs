using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Union.SqlServer
{
    [TestClass]
    public class UnionTest : UnionBaseTest
    {
        public UnionTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT [City] FROM [TestDatabase].[Dbo].[Customers] UNION SELECT [City] FROM [TestDatabase].[Dbo].[Suppliers]";

    }
}
