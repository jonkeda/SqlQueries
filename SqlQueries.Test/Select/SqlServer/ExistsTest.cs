using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ExistsTest : ExistsBaseTest
    {
        public ExistsTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE EXISTS(SELECT [CustomerID] FROM [Orders])";

    }
}