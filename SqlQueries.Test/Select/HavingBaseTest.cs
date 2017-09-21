using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class HavingBaseTest : BaseTest
    {
        protected HavingBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Having

        public abstract string HavingExpected { get; } // = "SELECT * FROM [TestDatabase].[Dbo].[Customers] HAVING [City] = @p0 AND [ContactName] <> [CustomerName]";

        [TestMethod]
        public void ConstructorHaving()
        {
            string statement = SelectCustomer().Having("City", "Daan").HavingField("ContactName", SqlOperator.NotEqual, "CustomerName").ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        [TestMethod]
        public void PropertiesHaving()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Having.Add(new HavingValue("City", "Daan"));
            select.Having.Add(new HavingField("ContactName", SqlOperator.NotEqual, "CustomerName"));

            string statement = select.ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        [TestMethod]
        public void FluentHaving()
        {
            string statement = SelectCustomer().Having("City", "Daan").HavingField("ContactName", SqlOperator.NotEqual, "CustomerName").ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        #endregion

    }
}
