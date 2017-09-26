using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class AverageBaseTest : BaseTest
    {
        protected AverageBaseTest(Type dbConnectionType) : base(dbConnectionType)
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
                .Column(new Average("TotalAmount"), new Average("[c]", "TotalAmount"), new Average("c", "Price", "p"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            Srt2.SqlQueries.Select select = SelectCustomerAs();
            select.Columns.Add(new Average("TotalAmount"));
            select.Columns.Add(new Average("[c]", "TotalAmount"));
            select.Columns.Add(new Average("c", "Price", "p"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs().Average("TotalAmount")
                .Columns().Average("[c]", "TotalAmount").Average("c", "Price", "p")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}
