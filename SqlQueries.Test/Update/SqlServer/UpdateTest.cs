using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Update.SqlServer
{
    [TestClass]
    public class UpdateTest : UpdateBaseTest
    {
        public UpdateTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "UPDATE [TestDatabase].[Dbo].[Customers] SET [CustomerName] = @p0";

        public override string TopExpected { get; } = "UPDATE [TestDatabase].[Dbo].[Customers] SET [CustomerName] = @p0";

    }
}
