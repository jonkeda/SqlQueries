using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class GreaterThanTest : GreaterThanBaseTest
    {
        public GreaterThanTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers] WHERE [City] > @p0 AND [CustomerName] > [ContactName]";

    }
}