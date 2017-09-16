using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Delete.Sqlite
{
    [TestClass]
    public class StatementTest
    {
        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Delete("TestTable").ToString(typeof(SQLiteConnection)); 

            Assert.AreEqual("DELETE FROM [TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Delete().Table("TestTable").ToString(typeof(SQLiteConnection));

            Assert.AreEqual("DELETE FROM [TestTable]", statement);
        }
    }
}
