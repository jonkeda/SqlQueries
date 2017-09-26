using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Delete.SqlServer
{
    [TestClass]
    public class DeleteTest : DeleteBaseTest
    {
        public DeleteTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "DELETE FROM [TestDatabase].[Dbo].[Customers]";

        public override string TopExpected { get; } = "DELETE TOP (10) FROM [TestDatabase].[Dbo].[Customers]";

    }
}
