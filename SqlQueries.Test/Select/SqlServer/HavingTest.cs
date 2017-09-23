using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class HavingTest : HavingBaseTest
    {
        public HavingTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] GROUP BY [City], [ContactName] HAVING [City] = @p0 AND [ContactName] <> [CustomerName]";

    }
}