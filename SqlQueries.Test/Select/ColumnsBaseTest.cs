using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class ColumnsBaseTest : BaseTest
    {
        protected ColumnsBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Columns

        public abstract string Expected { get; }

        protected override IEnumerable<string> GetExpectedSql()
        {
            yield return Expected;
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
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "TestDatabase.Dbo.Customers c",
                Columns = "Price"
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
