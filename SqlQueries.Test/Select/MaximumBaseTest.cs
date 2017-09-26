using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class MaximumBaseTest : BaseTest
    {
        protected MaximumBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorColumns()
        {
            string statement = SelectCustomerAs()
                .Column(new Maximum("TotalAmount"), new Maximum("c", "TotalAmount"), new Maximum("c", "Price", "p"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            Srt2.SqlQueries.Select select = SelectCustomerAs();
            select.Columns.Add(new Maximum("TotalAmount"));
            select.Columns.Add(new Maximum("c", "TotalAmount"));
            select.Columns.Add(new Maximum("c", "Price", "p"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs().Maximum("TotalAmount")
                .Columns().Maximum("c", "TotalAmount").Maximum("c", "Price", "p")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}