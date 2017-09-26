using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class InTest : InBaseTest
    {
        public InTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";

    }
}