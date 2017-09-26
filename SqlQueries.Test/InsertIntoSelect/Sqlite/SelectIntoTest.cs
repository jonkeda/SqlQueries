using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.InsertIntoSelect.Sqlite
{
    [TestClass]
    public class InsertIntoSelectTest : InsertIntoSelectBaseTest
    {
        public InsertIntoSelectTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "INSERT INTO [CopyCustomers] ([CustomerName], [ContactName]) SELECT [CustomerName], [ContactName] FROM [Customers]";

        public override string ExpectedStar { get; } = "INSERT INTO [CopyCustomers] SELECT * FROM [Customers]";
    }
}
