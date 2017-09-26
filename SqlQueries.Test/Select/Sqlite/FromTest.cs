using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class FromTest : FromBaseTest
    {
        public FromTest() : base(typeof(SQLiteConnection))
        {
        }

        protected override string SingleExpected { get; } = "SELECT * FROM [Customers]";

        protected override string MultipleExpected { get; } = "SELECT * FROM [Customers], [Orders]";

    }
}
