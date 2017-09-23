using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class AllTest : AllBaseTest
    {
        public AllTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [Country] = ALL (SELECT [Country] FROM [Suppliers])";
    }
}