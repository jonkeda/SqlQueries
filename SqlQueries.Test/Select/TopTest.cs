using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class TopBaseTest : BaseTest
    {
        protected TopBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Top

        protected abstract string TopExpected { get; }
        protected abstract string TopPercentageExpected { get; }


        [TestMethod]
        public void ConstructorTop()
        {
            string statement = new SqlQueries.Select("TestDatabase.Dbo.Customers", 10).ToString();

            Assert.AreEqual(TopExpected, statement);
        }

        [TestMethod]
        public void PropertiesTop()
        {
            string statement = new SqlQueries.Select
            {
                From = "TestDatabase.Dbo.Customers",
                Top = 10
            }.ToString();

            Assert.AreEqual(TopExpected, statement);
        }

        [TestMethod]
        public void PropertiesTopPercentage()
        {
            string statement = new SqlQueries.Select
            {
                From = "TestDatabase.Dbo.Customers",
                Top = new Top(10, true)
            }.ToString();

            Assert.AreEqual(TopPercentageExpected, statement);
        }

        [TestMethod]
        public void FluentTop()
        {
            string statement = new SqlQueries.Select().From("TestDatabase.Dbo.Customers").Top(10).ToString();

            Assert.AreEqual(TopExpected, statement);
        }

        [TestMethod]
        public void FluentTopPercentage()
        {
            string statement = new SqlQueries.Select().From("TestDatabase.Dbo.Customers").Top(10, true).ToString();

            Assert.AreEqual(TopPercentageExpected, statement);
        }

        #endregion

    }
}
