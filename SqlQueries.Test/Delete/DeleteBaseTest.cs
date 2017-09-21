using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Delete.SqlServer
{
    [TestClass]
    public abstract class DeleteBaseTest : BaseTest
    {
        protected DeleteBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string DeleteExpected { get; } //= "DELETE FROM [TestDatabase].[Dbo].[Customers]";

        public abstract string DeleteTopExpected { get; } //= "DELETE TOP 10 FROM [TestDatabase].[Dbo].[Customers]";

        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Delete("[TestDatabase].[Dbo].[Customers]").ToString(DbConnectionType); 

            Assert.AreEqual(DeleteExpected, statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = (new SqlQueries.Delete
            {
                From = "[TestDatabase].[Dbo].[Customers]"
            }).ToString(DbConnectionType);

            Assert.AreEqual(DeleteExpected, statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Delete().From("[TestDatabase].[Dbo].[Customers]").ToString(DbConnectionType);

            Assert.AreEqual(DeleteExpected, statement);
        }

        [TestMethod]
        public virtual void ConstructorTop()
        {
            string statement = new SqlQueries.Delete("[TestDatabase].[Dbo].[Customers]", 10).ToString(DbConnectionType);

            Assert.AreEqual(DeleteTopExpected, statement);
        }

        [TestMethod]
        public virtual void FluentTop()
        {
            string statement = new SqlQueries.Delete().From("[TestDatabase].[Dbo].[Customers]").Top(10).ToString(DbConnectionType);

            Assert.AreEqual(DeleteTopExpected, statement);
        }
    }
}
