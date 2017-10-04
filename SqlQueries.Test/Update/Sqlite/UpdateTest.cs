using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Update.Sqlite
{
    [TestClass]
    public class UpdateTest : UpdateBaseTest
    {
        public UpdateTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "UPDATE [Customers] SET [CustomerName] = @p0, [ContactName] = @p1";
    }
}
