using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class NotEqualTest : NotEqualBaseTest
    {
        public NotEqualTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [City] <> @p0 AND [CustomerName] <> [ContactName]";

    }
}