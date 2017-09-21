using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class LessThanBaseTest : BaseTest
    {
        protected LessThanBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }
        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where(new LessThanValue { Field = "City", Value = "Berlin" })
                .Where(new LessThan { Field = "CustomerName", ToField = "ContactName" })
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new LessThanValue("City", "Berlin"));
            select.Where.Add(new LessThan("CustomerName", "ContactName"));

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .LessThanValue("City", "Berlin")
                .LessThan("CustomerName", "ContactName")
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}