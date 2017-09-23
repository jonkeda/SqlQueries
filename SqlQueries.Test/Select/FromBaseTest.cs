using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    [TestClass]
    public abstract class FromBaseTest : BaseTest
    {
        protected FromBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region From

        protected abstract string SingleExpected { get; } 
        protected abstract string MultipleExpected { get; }

        protected override IEnumerable<string> GetExpectedSql()
        {
            yield return SingleExpected;
            yield return MultipleExpected;
        }

        [TestMethod]
        public void ConstructorSingle()
        {
            string statement = SelectCustomer().ToString(DbConnectionType);

            Assert.AreEqual(SingleExpected, statement);
        }

        [TestMethod]
        public void ConstructorMultiple()
        {
            string statement = SelectCustomer().From("TestDatabase.Dbo.Orders").ToString(DbConnectionType);

            Assert.AreEqual(MultipleExpected, statement);
        }

        [TestMethod]
        public void PropertiesSingle()
        {
            string statement = new SqlQueries.Select
            {
                From = "TestDatabase.Dbo.Customers"
            }.ToString(DbConnectionType);

            Assert.AreEqual(SingleExpected, statement);
        }

        [TestMethod]
        public void PropertiesMultiple()
        {
            string statement = new SqlQueries.Select
            {
                From = "TestDatabase.Dbo.Customers"
            }.From("TestDatabase.Dbo.Orders").ToString(DbConnectionType);

            Assert.AreEqual(MultipleExpected, statement);
        }

        [TestMethod]
        public void FluentSingle()
        {
            string statement = new SqlQueries.Select().From("TestDatabase.Dbo.Customers").ToString(DbConnectionType);

            Assert.AreEqual(SingleExpected, statement);
        }

        [TestMethod]
        public void FluentMultiple()
        {
            string statement = new SqlQueries.Select().From("TestDatabase.Dbo.Customers").From("TestDatabase.Dbo.Orders").ToString(DbConnectionType);

            Assert.AreEqual(MultipleExpected, statement);
        }

        #endregion
    }
}
