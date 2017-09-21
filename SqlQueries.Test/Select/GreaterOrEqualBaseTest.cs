using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class GreaterOrEqualBaseTest : BaseTest
    {
        protected GreaterOrEqualBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }
        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where(new GreaterOrEqualThanValue { Field = "City", Value = "Berlin" })
                .Where(new GreaterOrEqual { Field = "CustomerName", ToField = "ContactName" })
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new GreaterOrEqualThanValue("City", "Berlin"));
            select.Where.Add(new GreaterOrEqual("CustomerName", "ContactName"));

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .GreaterOrEqualThanValue("City", "Berlin")
                .GreaterOrEqual("CustomerName", "ContactName")
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}