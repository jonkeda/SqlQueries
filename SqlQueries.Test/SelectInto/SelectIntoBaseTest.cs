using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.SelectInto
{
    [TestClass]
    public abstract class SelectIntoBaseTest : BaseTest
    {
        protected SelectIntoBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; } // = "TRUNCATE TABLE [Db].[schem].[TestTable]";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public virtual void Constructor1()
        {
            string statement = new Srt2.SqlQueries.SelectInto("TestDatabase.Dbo.Customers", "[CustomerName], [ContactName]", "TestDatabase.Dbo.CopyCustomers")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor2()
        {
            string statement = new Srt2.SqlQueries.SelectInto("TestDatabase.Dbo.Customers", "[CustomerName], [ContactName]")
                .Into("TestDatabase.Dbo.CopyCustomers")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor3()
        {
            string statement = new Srt2.SqlQueries.SelectInto("TestDatabase.Dbo.Customers")
                .Columns("[CustomerName], [ContactName]")
                .Into("TestDatabase.Dbo.CopyCustomers")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor4()
        {
            string statement = new Srt2.SqlQueries.SelectInto()
                .From("TestDatabase.Dbo.Customers")
                .Columns("[CustomerName], [ContactName]")
                .Into("TestDatabase.Dbo.CopyCustomers")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        //[TestMethod]
        //public void Properties()
        //{
        //    string statement = (new SqlQueries.SelectInto
        //    {
        //        Table = "TestDatabase.Dbo.Customers"
        //    }).ToString(DbConnectionType);

        //    Assert.AreEqual(Expected, statement);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(QueryBuilderException))]
        //public void Properties2()
        //{
        //    string statement = (new SqlQueries.SelectInto
        //    {
        //        Table = null
        //    }).ToString(DbConnectionType);

        //}
        //[TestMethod]
        //public void Fluent()
        //{
        //    string statement = new SqlQueries.SelectInto().Table("TestDatabase.Dbo.Customers").ToString(DbConnectionType);

        //    Assert.AreEqual(Expected, statement);
        //}

    }
}
