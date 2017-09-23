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

        public abstract string StarExpected { get; }

        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public virtual void TestStarExpectedSql()
        {
            RunSql(StarExpected, Parameters);
        }


        [TestMethod]
        public void ConstructorColumnStar()
        {
            string statement = SelectCustomer().Column("*").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void ConstructorColumnStar2()
        {
            string statement = SelectCustomer().ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void ConstructorColumnTableStar()
        {
            string statement = SelectCustomerAs().Column("c.*").ToString(DbConnectionType);

            Assert.AreEqual(StarExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumnStar()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = {"[TestDatabase].[Dbo].[Customers]" },
                Columns = {"*" }
            };

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumnTableStar()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = {"[TestDatabase].[Dbo].[Customers] AS [c]" },
                Columns = {"c.*" }
            };

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(StarExpected, statement);
        }

        [TestMethod]
        public void FluentColumnStar()
        {
            string statement = SelectCustomer().Column("*").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumnTableStar()
        {
            string statement = SelectCustomerAs().Column("c.*").ToString(DbConnectionType);

            Assert.AreEqual(StarExpected, statement);
        }

        #endregion
    }
}