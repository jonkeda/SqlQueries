using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class GroupByTest : GroupByBaseTest
    {
        public GroupByTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string GroupByExpected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] GROUP BY [ContactName]";
    }
}