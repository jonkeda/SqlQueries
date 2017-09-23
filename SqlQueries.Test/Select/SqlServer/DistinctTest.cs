using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class DistinctTest : DistinctBaseTest
    {
        public DistinctTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT DISTINCT [City] FROM [TestDatabase].[Dbo].[Customers]";

    }
}