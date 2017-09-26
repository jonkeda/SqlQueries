using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
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
            Srt2.SqlQueries.Select select = new Srt2.SqlQueries.Select
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
            Srt2.SqlQueries.Select select = SelectCustomer();
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
            Srt2.SqlQueries.Select select = SelectCustomer();
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
