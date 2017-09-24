using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Conditions;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class IsNotNullBaseTest : BaseTest
    {
        protected IsNotNullBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where In

        public abstract string Expected { get; } // = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorIsNotNull()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where(new IsNotNull("Country"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesIsNotNull()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = {"Customers" }
            };
            select.Where.Add(new IsNotNull { Field = "Country"});

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentIsNotNull()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .IsNotNull("Country")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
