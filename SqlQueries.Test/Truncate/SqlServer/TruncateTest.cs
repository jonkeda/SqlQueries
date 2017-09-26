using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Truncate.SqlServer
{
    [TestClass]
    public class TruncateTest : TruncateBaseTest
    {
        public TruncateTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "TRUNCATE TABLE [TestDatabase].[Dbo].[Customers]";
    }
}
