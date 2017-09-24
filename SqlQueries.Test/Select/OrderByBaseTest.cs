using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class OrderByBaseTest : BaseTest
    {
        protected OrderByBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region OrderBy

        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorOrderBy()
        {
            string statement = SelectCustomer().OrderByField("CustomerName").OrderByFieldDescending("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }


        [TestMethod]
        public void Constructor2OrderBy()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = { "[TestDatabase].[Dbo].[Customers]" },
                OrderBy = { "CustomerName" }
            };
            select.OrderByFieldDescending("ContactName");
            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesOrderBy()
        {
            SqlQueries.Select select = SelectCustomer();
            select.OrderBy.Add(new OrderByField("CustomerName"));
            select.OrderBy.Add(new OrderByField
            {
                Field = "ContactName",
                Descending = true
            });

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties2OrderBy()
        {
            SqlQueries.Select select = SelectCustomer();
            select.OrderBy.Add(new Field("CustomerName"));
            select.OrderBy.Add(new OrderByField("ContactName", true));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentOrderBy()
        {
            string statement = SelectCustomer().OrderByField("CustomerName").OrderByFieldDescending("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void Fluent2OrderBy()
        {
            string statement = SelectCustomer().OrderBy("CustomerName").OrderByDescending("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void OperatorOrderBy()
        {
            OrderByCollection gb = "ContactNaam";
        }

        #endregion

    }
}
