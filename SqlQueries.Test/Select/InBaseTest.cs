using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class InBaseTest : BaseTest
    {
        protected InBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where In

        public abstract string InExpected { get; } // = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";


        [TestMethod]
        public void ConstructorIn()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where(new In("Country", new SqlQueries.Select("Suppliers", "Country")))
                .ToString();

            Assert.AreEqual(InExpected, statement);
        }

        [TestMethod]
        public void PropertiesIn()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "Customers"
            };
            select.Where.Add(new In { Field = "Country", Select = new SqlQueries.Select("Suppliers", "Country")});

            string statement = select.ToString();

            Assert.AreEqual(InExpected, statement);
        }

        [TestMethod]
        public void FluentIn()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .In("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(InExpected, statement);
        }

        #endregion

    }
}
