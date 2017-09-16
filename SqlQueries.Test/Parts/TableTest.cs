using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;

namespace SqlQueries.Test.Parts
{
    [TestClass]
    public class TableTest
    {
        [TestMethod]
        public void Constructor1()
        {
            Table table = new Table("c");

            AssertTable("", "", "c", "", table);
        }

        [TestMethod]
        public void Constructor2()
        {
            Table table = new Table("c d");

            AssertTable("", "", "c", "d", table);
        }

        [TestMethod]
        public void Constructor3()
        {
            Table table = new Table("c AS d");

            AssertTable("", "", "c", "d", table);
        }

        [TestMethod]
        public void Constructor4()
        {
            Table table = new Table("a.c");

            AssertTable("a", "", "c", "", table);
        }

        [TestMethod]
        public void Constructor5()
        {
            Table table = new Table("a.b.c");

            AssertTable("a", "b", "c", "", table);
        }

        [TestMethod]
        public void Constructor6()
        {
            Table table = new Table("a.b.c AS d");

            AssertTable("a", "b", "c", "d", table);
        }

        [TestMethod]
        public void Constructor7()
        {
            Table table = new Table("a.b.c d");

            AssertTable("a", "b", "c", "d", table);
        }

        private static void AssertTable(string database, string schema, string tableName, string alias, Table table)
        {
            Assert.AreEqual(database, table.Database);
            Assert.AreEqual(schema, table.Schema);
            Assert.AreEqual(tableName, table.TableName);
            Assert.AreEqual(alias, table.Alias);
        }

        //[TestMethod]
        //public void Fluent()
        //{
        //    string statement = new SqlQueries.Delete().Table("TestTable").ToString(typeof(SQLiteConnection));

        //    Assert.AreEqual("DELETE FROM [TestTable]", statement);
        //}
    }
}
