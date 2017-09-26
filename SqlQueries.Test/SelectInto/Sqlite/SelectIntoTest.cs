using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Test.SelectInto.Sqlite
{
    [TestClass]
    public class SelectIntoTest : SelectIntoBaseTest
    {
        public SelectIntoTest() : base(typeof(SQLiteConnection))
        {
        }
        public override string Expected { get; } = "SELECT [CustomerName], [ContactName] INTO [CopyCustomers] FROM [Customers]";

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestExpectedSql()
        {
            base.TestExpectedSql();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Constructor1()
        {
            base.Constructor1();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Constructor2()
        {
            base.Constructor2();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Constructor3()
        {
            base.Constructor3();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void Constructor4()
        {
            base.Constructor4();
        }

    }
}
