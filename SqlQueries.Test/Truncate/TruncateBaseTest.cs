using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Exceptions;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Truncate
{
    [TestClass]
    public abstract class TruncateBaseTest : BaseTest
    {
        protected TruncateBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; } // = "TRUNCATE TABLE [Db].[schem].[TestTable]";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Truncate("TestDatabase.Dbo.Customers").ToString(DbConnectionType); 

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = (new SqlQueries.Truncate
            {
                Table = "TestDatabase.Dbo.Customers"
            }).ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderException))]
        public void Properties2()
        {
            string statement = (new SqlQueries.Truncate
            {
                Table = null
            }).ToString(DbConnectionType);
            
        }
        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Truncate().Table("TestDatabase.Dbo.Customers").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}
