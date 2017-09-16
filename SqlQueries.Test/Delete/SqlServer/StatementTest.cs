using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Delete.SqlServer
{
    [TestClass]
    public class StatementTest
    {
        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Delete("Db.schem.TestTable").ToString(); 

            Assert.AreEqual("DELETE FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = (new SqlQueries.Delete
            {
                Table = "[Db].[schem].[TestTable]"
            }).ToString();

            Assert.AreEqual("DELETE FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Delete().Table("Db.schem.TestTable").ToString();

            Assert.AreEqual("DELETE FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void ConstructorTop()
        {
            string statement = new SqlQueries.Delete("Db.schem.TestTable", 10).ToString();

            Assert.AreEqual("DELETE TOP (10) FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void FluentTop()
        {
            string statement = new SqlQueries.Delete().Table("Db.schem.TestTable").Top(10).ToString();

            Assert.AreEqual("DELETE TOP (10) FROM [Db].[schem].[TestTable]", statement);
        }
    }
}
