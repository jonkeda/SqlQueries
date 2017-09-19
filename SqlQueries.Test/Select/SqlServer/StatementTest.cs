﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                From = "[Db].[schem].[TestTable]"
            }.ToString();

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Select().From("Db.schem.TestTable").ToString();

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
                From = "[Db].[schem].[TestTable]",
                Top = 10
            }.ToString();

            Assert.AreEqual("SELECT TOP (10) * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void FluentTop()
        {
            string statement = new SqlQueries.Select().From("Db.schem.TestTable").Top(10).ToString();

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
                From = "DimEmployee e",
                Columns =  "e.*"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void FluentColumnStar()
        {
            string statement = new SqlQueries.Select().Column("e.*").From("DimEmployee e").OrderBy("LastName").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        #endregion

        #region Columns

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
                From = "DimEmployee e",
                Columns = "[b], [a].[b], [a].[b] as [c], [b] as [c]"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = new SqlQueries.Select().Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]").From("DimEmployee e").OrderBy("LastName").ToString();

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
                From = "DimEmployee"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void FluentOrderBy()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").OrderBy("LastName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        #endregion

        #region GroupBy

        private const string GroupByExpected = "SELECT * FROM [DimEmployee] GROUP BY [LastName]";

        [TestMethod]
        public void ConstructorGroupBy()
        {
            string statement = new SqlQueries.Select("DimEmployee").GroupBy("LastName").ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        [TestMethod]
        public void PropertiesGroupBy()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.GroupBy.Add(new GroupByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        [TestMethod]
        public void FluentGroupBy()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").GroupBy("LastName").ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        #endregion


        #region Where

        private const string WhereExpected = "SELECT * FROM [DimEmployee] WHERE [LastName] = @p1 AND [Number] > [Count]";

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = new SqlQueries.Select("DimEmployee").Where("LastName", "Daan").WhereField("Number", SqlOperator.Greater, "Count").ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.Where.Add(new WhereValue("LastName", "Daan"));
            select.Where.Add(new WhereField("Number", SqlOperator.Greater, "Count"));

            string statement = select.ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").Where("LastName", "Daan").WhereField("Number", SqlOperator.Greater, "Count").ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        #endregion

        #region Having

        private const string HavingExpected = "SELECT * FROM [DimEmployee] HAVING [LastName] = @p1 AND [Number] > [Count]";

        [TestMethod]
        public void ConstructorHaving()
        {
            string statement = new SqlQueries.Select("DimEmployee").Having("LastName", "Daan").HavingField("Number", SqlOperator.Greater, "Count").ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        [TestMethod]
        public void PropertiesHaving()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.Having.Add(new HavingValue("LastName", "Daan"));
            select.Having.Add(new HavingField("Number", SqlOperator.Greater, "Count"));

            string statement = select.ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        [TestMethod]
        public void FluentHaving()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").Having("LastName", "Daan").HavingField("Number", SqlOperator.Greater, "Count").ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        #endregion

        #region Join

        private const string JoinExpected = "SELECT * FROM [DimEmployee] AS [e] INNER JOIN [DimOrder] AS [o] ON [e].[Id] = [o].[EmployeeId]";

        [TestMethod]
        public void ConstructorJoin()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        [TestMethod]
        public void PropertiesJoin()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e"
            };
            select.Joins.Add(new Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId"));

            string statement = select.ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        [TestMethod]
        public void FluentJoin()
        {
            string statement = new SqlQueries.Select().From("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        #endregion

    }
}
