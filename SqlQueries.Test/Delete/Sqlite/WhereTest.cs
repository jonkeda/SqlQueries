using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Delete.Sqlite
{
    [TestClass]
    public class WhereTest : WhereBaseTest
    {
        public WhereTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "DELETE FROM [Customers] WHERE [City] = @p0 AND [CustomerName] = [ContactName]";

    }
}