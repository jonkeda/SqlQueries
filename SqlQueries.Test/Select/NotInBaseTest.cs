using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class NotInBaseTest : BaseTest
    {
        protected NotInBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where In

        public abstract string Expected { get; } // = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";


        [TestMethod]
        public void ConstructorNotIn()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where(new NotIn("Country", new SqlQueries.Select("Suppliers", "Country")))
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesNotIn()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "Customers"
            };
            select.Where.Add(new NotIn { Field = "Country", Select = new SqlQueries.Select("Suppliers", "Country")});

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentNotIn()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .NotIn("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
