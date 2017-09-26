using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class ColumnsBaseTest : BaseTest
    {
        protected ColumnsBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Columns

        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorColumns()
        {
            string statement = SelectCustomerAs().Columns("[Price], [c].[Price], [c].[Price] as [p], [Price] AS [p]").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            Srt2.SqlQueries.Select select = new Srt2.SqlQueries.Select
            {
                From = { "TestDatabase.Dbo.Customers c" },
                Columns = { "Price" }
            };
            select.Columns.Add(new Field("c", "Price"));
            select.Columns.Add("[c].[Price] as [p]");
            select.Columns.Add("[Price] as [p]");


            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs()
                .Columns("[Price], [c].[Price], [c].[Price] as [p], [Price] as [p]").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
