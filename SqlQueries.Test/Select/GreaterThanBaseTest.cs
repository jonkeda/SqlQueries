using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class GreaterThanBaseTest : BaseTest
    {
        protected GreaterThanBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }
        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where(new GreaterThanValue { Field = "City", Value = "Berlin" })
                .Where(new GreaterThan { Field = "CustomerName", ToField = "ContactName" })
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new GreaterThanValue("City", "Berlin"));
            select.Where.Add(new GreaterThan("CustomerName", "ContactName"));

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .GreaterThanValue("City", "Berlin")
                .GreaterThan("CustomerName", "ContactName")
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}