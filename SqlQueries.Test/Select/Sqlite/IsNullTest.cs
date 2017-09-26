using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{


    [TestClass]
    public class IsNullTest : IsNullBaseTest
    {
        public IsNullTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE [Country] IS NULL";

    }
}