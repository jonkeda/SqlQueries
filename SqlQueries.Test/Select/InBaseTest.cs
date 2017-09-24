using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Conditions;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class InBaseTest : BaseTest
    {
        protected InBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where In

        public abstract string Expected { get; } // = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorIn()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where(new In("Country", new SqlQueries.Select("Suppliers", "Country")))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesIn()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = {"Customers" }
            };
            select.Where.Add(new In { Field = "Country", Select = new SqlQueries.Select("Suppliers", "Country")});

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentIn()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .In("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
