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

        public abstract string Expected { get; } // = "SELECT * FROM [TestDatabase].[Dbo].[Customers] HAVING [City] = @p0 AND [ContactName] <> [CustomerName]";

        public override object[] Parameters { get; } = {"Daan"};

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorHaving()
        {
            string statement = SelectCustomer().GroupBy("City, ContactName").Having("City", "Daan").HavingField("ContactName", SqlOperator.NotEqual, "CustomerName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesHaving()
        {
            SqlQueries.Select select = SelectCustomer().GroupBy("City, ContactName");
            select.Having.Add(new HavingValue("City", "Daan"));
            select.Having.Add(new HavingField("ContactName", SqlOperator.NotEqual, "CustomerName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentHaving()
        {
            string statement = SelectCustomer().GroupBy("City, ContactName").Having("City", "Daan").HavingField("ContactName", SqlOperator.NotEqual, "CustomerName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
