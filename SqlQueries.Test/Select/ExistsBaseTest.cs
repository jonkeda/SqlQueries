using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class ExistsBaseTest : BaseTest
    {
        protected ExistsBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }


        #region Where Exist

        public abstract string Expected { get; } //= @"SELECT * FROM [Suppliers] WHERE EXISTS(SELECT [ProductName] FROM [Products])";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorExist()
        {
            string statement = SelectCustomer()
                .Where(new Exists(new Srt2.SqlQueries.Select("Orders", "CustomerID")))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesExist()
        {
            Srt2.SqlQueries.Select select = new Srt2.SqlQueries.Select
            {
                From = { "[TestDatabase].[Dbo].[Customers]" }
            };
            select.Where.Add(new Exists {Select = new Srt2.SqlQueries.Select("Orders", "CustomerID")});

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentExist()
        {
            string statement = SelectCustomer()
                .Exists(new Srt2.SqlQueries.Select("Orders", "CustomerID"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion
    }
}
