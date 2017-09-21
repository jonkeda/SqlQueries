using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class OrderByBaseTest : BaseTest
    {
        protected OrderByBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region OrderBy

        private const string OrderByExpected = "SELECT * FROM [TestDatabase].[Dbo].[Customers] ORDER BY [CustomerName]";

        [TestMethod]
        public void ConstructorOrderBy()
        {
            string statement = SelectCustomer().OrderByField("CustomerName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void PropertiesOrderBy()
        {
            SqlQueries.Select select = SelectCustomer();
            select.OrderBy.Add(new OrderByField("CustomerName"));

            string statement = select.ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void FluentOrderBy()
        {
            string statement = SelectCustomer().OrderByField("CustomerName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        #endregion

    }
}
