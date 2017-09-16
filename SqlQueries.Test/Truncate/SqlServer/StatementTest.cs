using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Truncate.SqlServer
{
    [TestClass]
    public class StatementTest
    {
        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Truncate("Db.schem.TestTable").ToString(); 

            Assert.AreEqual("TRUNCATE TABLE [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = (new SqlQueries.Truncate
            {
                Table = "[Db].[schem].[TestTable]"
            }).ToString();

            Assert.AreEqual("TRUNCATE TABLE [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Truncate().Table("Db.schem.TestTable").ToString();

            Assert.AreEqual("TRUNCATE TABLE [Db].[schem].[TestTable]", statement);
        }

    }
}
