using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class LessOrEqualBaseTest : BaseTest
    {
        protected LessOrEqualBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }
        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where(new LessOrEqualThanValue { Field = "City", Value = "Berlin" })
                .Where(new LessOrEqual { Field = "CustomerName", ToField = "ContactName" })
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new LessOrEqualThanValue("City", "Berlin"));
            select.Where.Add(new LessOrEqual("CustomerName", "ContactName"));

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .LessOrEqualThanValue("City", "Berlin")
                .LessOrEqual("CustomerName", "ContactName")
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}