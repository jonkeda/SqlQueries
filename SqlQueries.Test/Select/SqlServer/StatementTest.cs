using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class StatementTest
    {
        #region Simple

        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Select("Db.schem.TestTable").ToString(); 

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = new SqlQueries.Select
            {
                Table = "[Db].[schem].[TestTable]"
            }.ToString();

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Select().Table("Db.schem.TestTable").ToString();

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }
        #endregion

        #region Top

        [TestMethod]
        public void ConstructorTop()
        {
            string statement = new SqlQueries.Select("Db.schem.TestTable", 10).ToString();

            Assert.AreEqual("SELECT TOP (10) * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void PropertiesTop()
        {
            string statement = new SqlQueries.Select
            {
                Table = "[Db].[schem].[TestTable]",
                Top = 10
            }.ToString();

            Assert.AreEqual("SELECT TOP (10) * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void FluentTop()
        {
            string statement = new SqlQueries.Select().Table("Db.schem.TestTable").Top(10).ToString();

            Assert.AreEqual("SELECT TOP (10) * FROM [Db].[schem].[TestTable]", statement);
        }

        #endregion

        #region Column Star

        private const string ColumnStarExpected = "SELECT [e].[*] FROM [DimEmployee] AS [e] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorColumnStar()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Column("e.*").OrderBy("LastName").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumnStar()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                Table = "DimEmployee e",
                Columns =  "e.*"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void FluentColumnStar()
        {
            string statement = new SqlQueries.Select().Column("e.*").Table("DimEmployee e").OrderBy("LastName").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        #endregion

        #region Column Star

        private const string ColumnsExpected = "SELECT [b], [a].[b], [a].[b] AS [c], [b] AS [c] FROM [DimEmployee] AS [e] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorColumns()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]").OrderBy("LastName").ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                Table = "DimEmployee e",
                Columns = "[b], [a].[b], [a].[b] as [c], [b] as [c]"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = new SqlQueries.Select().Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]").Table("DimEmployee e").OrderBy("LastName").ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        #endregion


        #region OrderBy

        private const string OrderByExpected = "SELECT * FROM [DimEmployee] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorOrderBy()
        {
            string statement = new SqlQueries.Select("DimEmployee").OrderBy("LastName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void PropertiesOrderBy()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                Table = "DimEmployee"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void FluentOrderBy()
        {
            string statement = new SqlQueries.Select().Table("DimEmployee").OrderBy("LastName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        #endregion
    }
}
