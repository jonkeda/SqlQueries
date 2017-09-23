using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class HavingTest : HavingBaseTest
    {
        public HavingTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers] GROUP BY [City], [ContactName] HAVING [City] = @p0 AND [ContactName] <> [CustomerName]";

    }
}