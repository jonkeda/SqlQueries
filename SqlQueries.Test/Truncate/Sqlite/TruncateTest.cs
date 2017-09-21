using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Truncate.Sqlite
{
    [TestClass]
    public class TruncateTest : TruncateBaseTest
    {
        public TruncateTest() : base(typeof(SQLiteConnection))
        {
        }
        public override string TruncateExpected { get; } = "DELETE FROM [Customers]";
    }
}
