using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class ColumnStarBaseTest : BaseTest
    {
        protected ColumnStarBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Column Star

        public abstract string ColumnTableStarExpected { get; }

        public abstract string ColumnStarExpected { get; }


        [TestMethod]
        public void ConstructorColumnStar()
        {
            string statement = SelectCustomer().Column("*").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void ConstructorColumnTableStar()
        {
            string statement = SelectCustomerAs().Column("c.*").ToString();

            Assert.AreEqual(ColumnTableStarExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumnStar()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "[TestDatabase].[Dbo].[Customers]",
                Columns = "*"
            };

            string statement = select.ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumnTableStar()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "[TestDatabase].[Dbo].[Customers] AS [c]",
                Columns = "c.*"
            };

            string statement = select.ToString();

            Assert.AreEqual(ColumnTableStarExpected, statement);
        }

        [TestMethod]
        public void FluentColumnStar()
        {
            string statement = SelectCustomer().Column("*").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void FluentColumnTableStar()
        {
            string statement = SelectCustomerAs().Column("c.*").ToString();

            Assert.AreEqual(ColumnTableStarExpected, statement);
        }

        #endregion
    }
}