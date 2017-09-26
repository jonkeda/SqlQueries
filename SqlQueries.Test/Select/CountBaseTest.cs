using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class CountBaseTest : BaseTest
    {
        protected CountBaseTest(Type dbConnectionType) : base(dbConnectionType)
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
                .Column(new Count(), new Count("TotalAmount"), new Count("c", "TotalAmount"), new Count("c", "Price", "p"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            Srt2.SqlQueries.Select select = SelectCustomerAs();
            select.Columns.Add(new Count());
            select.Columns.Add(new Count("TotalAmount"));
            select.Columns.Add(new Count("c", "TotalAmount"));
            select.Columns.Add(new Count("c", "Price", "p"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs().Count().Count("TotalAmount")
                .Columns().Count("c", "TotalAmount").Count("c", "Price", "p")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}