using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class NotInTest : InBaseTest
    {
        public NotInTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string InExpected { get; } = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";

    }
}