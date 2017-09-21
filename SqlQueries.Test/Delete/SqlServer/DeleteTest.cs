using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Delete.SqlServer
{
    [TestClass]
    public class DeleteTest : DeleteBaseTest
    {
        public DeleteTest() : base(typeof(SqlConnection))
        {
        }

        public override string DeleteExpected { get; } = "DELETE FROM [TestDatabase].[Dbo].[Customers]";

        public override string DeleteTopExpected { get; } = "DELETE TOP 10 FROM [TestDatabase].[Dbo].[Customers]";

    }
}
