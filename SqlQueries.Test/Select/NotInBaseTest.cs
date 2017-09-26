using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class NotInBaseTest : BaseTest
    {
        protected NotInBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where In

        public abstract string Expected { get; } // = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";
        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorNotIn()
        {
            string statement = new Srt2.SqlQueries.Select("Customers")
                .Where(new NotIn("Country", new Srt2.SqlQueries.Select("Suppliers", "Country")))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesNotIn()
        {
            Srt2.SqlQueries.Select select = new Srt2.SqlQueries.Select
            {
                From = {"Customers" }
            };
            select.Where.Add(new NotIn { Field = "Country", Select = new Srt2.SqlQueries.Select("Suppliers", "Country")});

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentNotIn()
        {
            string statement = new Srt2.SqlQueries.Select()
                .From("Customers")
                .NotIn("Country", new Srt2.SqlQueries.Select("Suppliers", "Country"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
