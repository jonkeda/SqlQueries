using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Delete
{
    public abstract class WhereBaseTest : BaseTest
    {
        protected WhereBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }
        public override object[] Parameters { get; } = { "Berlin" };

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = new SqlQueries.Delete("[TestDatabase].[Dbo].[Customers]")
                .Where("City", "Berlin")
                .WhereField("CustomerName", SqlOperator.Equal, "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties1Where()
        {
            SqlQueries.Delete select = DeleteCustomer();
            select.Where.Add(new EqualToValue("City", "Berlin"));
            select.Where.Add(new Equal("CustomerName", "ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties2Where()
        {
            SqlQueries.Delete select = DeleteCustomer();
            select.Add(new EqualToValue("City", "Berlin"));
            select.Add(new Equal("CustomerName", "ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere1()
        {
            string statement = DeleteCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", SqlOperator.Equal, "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void FluentWhere2()
        {
            string statement = DeleteCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere3()
        {
            string statement = DeleteCustomer()
                .EqualToValue("City", "Berlin")
                .Equal("CustomerName", "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
