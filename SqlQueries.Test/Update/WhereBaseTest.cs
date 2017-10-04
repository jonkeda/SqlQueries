using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Update
{
    public abstract class WhereBaseTest : BaseTest
    {
        protected WhereBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }
        public override object[] Parameters { get; } = { "Berlin", "Boel Namen" };

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = new Srt2.SqlQueries.Update("[TestDatabase].[Dbo].[Customers]").Set("CustomerName", "Boel Namen")
                .Where("City", "Berlin")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties1Where()
        {
            Srt2.SqlQueries.Update select = UpdateCustomer().Set("CustomerName", "Boel Namen");
            select.Where.Add(new EqualToValue("City", "Berlin"));
            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties2Where()
        {
            Srt2.SqlQueries.Update select = UpdateCustomer().Set("CustomerName", "Boel Namen");
            select.Add(new EqualToValue("City", "Berlin"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere1()
        {
            string statement = UpdateCustomer()
                .Set("CustomerName", "Boel Namen")
                .Where("City", "Berlin")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void FluentWhere2()
        {
            string statement = UpdateCustomer()
                .Set("CustomerName", "Boel Namen")
                .Where("City", "Berlin")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere3()
        {
            string statement = UpdateCustomer()
                .Set("CustomerName", "Boel Namen")
                .EqualToValue("City", "Berlin")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
