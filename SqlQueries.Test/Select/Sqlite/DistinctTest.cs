using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class DistinctTest : DistinctBaseTest
    {
        public DistinctTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT DISTINCT [City] FROM [Customers]";

    }
}