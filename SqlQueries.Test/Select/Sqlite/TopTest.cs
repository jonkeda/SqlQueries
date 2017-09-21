using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class TopTest : TopBaseTest
    {
        public TopTest() : base(typeof(SQLiteConnection))
        {
        }

        protected override string TopExpected { get; } = "SELECT TOP 10 * FROM [TestDatabase].[Dbo].[Customers]";

        protected override string TopPercentageExpected { get; } =
            "SELECT TOP 10 PERCENTAGE * FROM [TestDatabase].[Dbo].[Customers]";
    }
}
