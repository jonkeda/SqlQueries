using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.InsertIntoSelect.SqlServer
{
    [TestClass]
    public class InsertIntoSelectTest : InsertIntoSelectBaseTest
    {
        public InsertIntoSelectTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "INSERT INTO [TestDatabase].[Dbo].[CopyCustomers] ([CustomerName], [ContactName]) SELECT [CustomerName], [ContactName] FROM [TestDatabase].[Dbo].[Customers]";

        public override string ExpectedStar { get; } = "INSERT INTO [TestDatabase].[Dbo].[CopyCustomers] SELECT * FROM [TestDatabase].[Dbo].[Customers]";


    }
}
