using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class FromTest : FromBaseTest
    {
        public FromTest() : base(typeof(SqlConnection))
        {
        }
        
        protected override string SingleExpected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers]";
        protected override string MultipleExpected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers], [TestDatabase].[Dbo].[Orders]";

    }
}
