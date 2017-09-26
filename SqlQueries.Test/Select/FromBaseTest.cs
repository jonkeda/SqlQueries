using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
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

        protected override string GetExpectedSql()
        {
            return SingleExpected;
        }

        [TestMethod]
        public virtual void TestMultipleExpectedSql()
        {
            RunSql(MultipleExpected, Parameters);
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
            string statement = new Srt2.SqlQueries.Select
            {
                From = {"TestDatabase.Dbo.Customers" }
            }.ToString(DbConnectionType);

            Assert.AreEqual(SingleExpected, statement);
        }

        [TestMethod]
        public void PropertiesMultiple()
        {
            string statement = new Srt2.SqlQueries.Select
            {
                From = {"TestDatabase.Dbo.Customers" }
            }.From("TestDatabase.Dbo.Orders").ToString(DbConnectionType);

            Assert.AreEqual(MultipleExpected, statement);
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void PropertiesFromIsNull()
        {
            string statement = new Srt2.SqlQueries.Select
            {
                
            }.ToString(DbConnectionType);

            Assert.AreEqual(MultipleExpected, statement);
        }

        [TestMethod]
        public void FluentSingle()
        {
            string statement = new Srt2.SqlQueries.Select().From("TestDatabase.Dbo.Customers").ToString(DbConnectionType);

            Assert.AreEqual(SingleExpected, statement);
        }

        [TestMethod]
        public void FluentMultiple()
        {
            string statement = new Srt2.SqlQueries.Select().From("TestDatabase.Dbo.Customers").From("TestDatabase.Dbo.Orders").ToString(DbConnectionType);

            Assert.AreEqual(MultipleExpected, statement);
        }

        #endregion
    }
}
