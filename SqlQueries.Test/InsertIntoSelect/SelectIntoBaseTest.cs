using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.InsertIntoSelect
{
    [TestClass]
    public abstract class InsertIntoSelectBaseTest : BaseTest
    {
        protected InsertIntoSelectBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; } // = "TRUNCATE TABLE [Db].[schem].[TestTable]";

        public abstract string ExpectedStar { get; } // = "TRUNCATE TABLE [Db].[schem].[TestTable]";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public virtual void TestExpectedStart()
        {
            RunSql(ExpectedStar, Parameters);
        }


        [TestMethod]
        public virtual void Constructor1()
        {
            string statement = new Srt2.SqlQueries.InsertIntoSelect("TestDatabase.Dbo.CopyCustomers", "[CustomerName], [ContactName]", 
                SelectCustomer().Columns("[CustomerName], [ContactName]"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor2()
        {
            string statement = new Srt2.SqlQueries.InsertIntoSelect("TestDatabase.Dbo.CopyCustomers", "[CustomerName], [ContactName]")
                .Select(SelectCustomer().Columns("[CustomerName], [ContactName]"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor3()
        {
            string statement = new Srt2.SqlQueries.InsertIntoSelect("TestDatabase.Dbo.CopyCustomers")
                .Columns("[CustomerName], [ContactName]")
                .Select(SelectCustomer().Columns("[CustomerName], [ContactName]"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor4()
        {
            string statement = new Srt2.SqlQueries.InsertIntoSelect()
                .Select(SelectCustomer().Columns("[CustomerName], [ContactName]"))
                .Columns("[CustomerName], [ContactName]")
                .Into("TestDatabase.Dbo.CopyCustomers")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor5()
        {
            var select = new Srt2.SqlQueries.InsertIntoSelect()
                .Select(SelectCustomer().Columns("[CustomerName], [ContactName]"))
                .Into("TestDatabase.Dbo.CopyCustomers");

            select.Add("[CustomerName]");
            select.Add("[ContactName]");

            string statement   = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void ConstructorStar1()
        {
            string statement = new Srt2.SqlQueries.InsertIntoSelect()
                .Select(SelectCustomer())
                .Into("TestDatabase.Dbo.CopyCustomers")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedStar, statement);
        }

        //[TestMethod]
        //public void Properties()
        //{
        //    string statement = (new SqlQueries.InsertIntoSelect
        //    {
        //        Table = "TestDatabase.Dbo.Customers"
        //    }).ToString(DbConnectionType);

        //    Assert.AreEqual(Expected, statement);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(QueryBuilderException))]
        //public void Properties2()
        //{
        //    string statement = (new SqlQueries.InsertIntoSelect
        //    {
        //        Table = null
        //    }).ToString(DbConnectionType);

        //}
        //[TestMethod]
        //public void Fluent()
        //{
        //    string statement = new SqlQueries.InsertIntoSelect().Table("TestDatabase.Dbo.Customers").ToString(DbConnectionType);

        //    Assert.AreEqual(Expected, statement);
        //}

    }
}
