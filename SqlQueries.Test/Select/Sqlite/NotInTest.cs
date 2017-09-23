using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class NotInTest : NotInBaseTest
    {
        public NotInTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE [Country] NOT IN (SELECT [Country] FROM [Suppliers])";

    }
}