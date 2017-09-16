using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Truncate.Sqlite
{
    [TestClass]
    public class StatementTest
    {
        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Truncate("TestTable").ToString(typeof(SQLiteConnection)); 

            Assert.AreEqual("DELETE FROM [TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Truncate().Table("TestTable").ToString(typeof(SQLiteConnection));

            Assert.AreEqual("DELETE FROM [TestTable]", statement);
        }
    }
}
