using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.SelectInto.SqlServer
{
    [TestClass]
    public class SelectIntoTest : SelectIntoBaseTest
    {
        public SelectIntoTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT [CustomerName], [ContactName] INTO [TestDatabase].[Dbo].[CopyCustomers] FROM [TestDatabase].[Dbo].[Customers]";
    }
}
