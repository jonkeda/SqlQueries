using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class IsNotNullTest : IsNotNullBaseTest
    {
        public IsNotNullTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE [Country] IS NOT NULL";

    }
}