using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Update.Sqlite
{
    [TestClass]
    public class WhereTest : WhereBaseTest
    {
        public WhereTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "UPDATE [Customers] SET [CustomerName] = @p0 WHERE [City] = @p1";

    }
}