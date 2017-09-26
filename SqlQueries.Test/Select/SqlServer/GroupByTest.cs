using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class GroupByTest : GroupByBaseTest
    {
        public GroupByTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] GROUP BY [ContactName]";
    }
}