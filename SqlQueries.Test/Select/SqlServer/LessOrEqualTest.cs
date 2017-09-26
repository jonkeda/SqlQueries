using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class LessOrEqualTest : LessOrEqualBaseTest
    {
        public LessOrEqualTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [City] <= @p0 AND [CustomerName] <= [ContactName]";

    }
}