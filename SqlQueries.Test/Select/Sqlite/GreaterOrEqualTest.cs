using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class GreaterOrEqualTest : GreaterOrEqualBaseTest
    {
        public GreaterOrEqualTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers] WHERE [City] >= @p0 AND [CustomerName] >= [ContactName]";

    }
}