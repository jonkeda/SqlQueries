using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Delete
{
    [TestClass]
    public abstract class DeleteBaseTest : BaseTest
    {
        protected DeleteBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; } 

        public abstract string TopExpected { get; } 

        protected override string GetExpectedSql()
        {
            return Expected;
            //yield return TopExpected;
        }

        [TestMethod]
        public virtual void TestTopExpectedSql()
        {
            RunSql(TopExpected, null);
        }


        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Delete("[TestDatabase].[Dbo].[Customers]").ToString(DbConnectionType); 

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = (new SqlQueries.Delete
            {
                From = "[TestDatabase].[Dbo].[Customers]"
            }).ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Fluent1()
        {
            string statement = new SqlQueries.Delete().From("[TestDatabase].[Dbo].[Customers]").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void ConstructorTop()
        {
            string statement = new SqlQueries.Delete("[TestDatabase].[Dbo].[Customers]", 10).ToString(DbConnectionType);

            Assert.AreEqual(TopExpected, statement);
        }

        [TestMethod]
        public virtual void FluentTop()
        {
            string statement = new SqlQueries.Delete().From("[TestDatabase].[Dbo].[Customers]").Top(10).ToString(DbConnectionType);

            Assert.AreEqual(TopExpected, statement);
        }
    }
}
