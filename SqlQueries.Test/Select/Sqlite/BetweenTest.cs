using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class BetweenTest : BetweenBaseTest
    {
        public BetweenTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers] WHERE [Country] BETWEEN @p0 AND @p1";
    }
}