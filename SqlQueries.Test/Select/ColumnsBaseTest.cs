using System;
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

        public abstract string ColumnsExpected { get; } // = "SELECT [b], [a].[b], [a].[b] AS [c], [b] AS [c] FROM [DimEmployee] AS [e]";

        [TestMethod]
        public void ConstructorColumns()
        {
            string statement = SelectCustomerAs().Columns("[b], [a].[b], [a].[b] as [c], [b] AS [c]").ToString(DbConnectionType);

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "TestDatabase.Dbo.Customers c",
                Columns = "[b], [a].[b], [a].[b] as [c]"
            };
            select.Columns.Add("[b] as [c]");

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs()
                .Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]").ToString(DbConnectionType);

            Assert.AreEqual(ColumnsExpected, statement);
        }

        #endregion

    }
}
