using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class ExistsTest : ExistsBaseTest
    {
        public ExistsTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE EXISTS(SELECT [CustomerID] FROM [Orders])";

    }
}