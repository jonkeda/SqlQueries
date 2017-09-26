using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Truncate.Sqlite
{
    [TestClass]
    public class TruncateTest : TruncateBaseTest
    {
        public TruncateTest() : base(typeof(SQLiteConnection))
        {
        }
        public override string Expected { get; } = "DELETE FROM [Customers]";
    }
}
