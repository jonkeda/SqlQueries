using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Union
{
    [TestClass]
    public abstract class UnionBaseTest : BaseTest
    {
        protected UnionBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; } // = "TRUNCATE TABLE [Db].[schem].[TestTable]";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void Constructor1()
        {
            string statement = new SqlQueries.Union(
                new SqlQueries.Select("[TestDatabase].[Dbo].[Customers]").Columns("City"), 
                new SqlQueries.Select("[TestDatabase].[Dbo].[Suppliers]").Columns("City"))
                .ToString(DbConnectionType); 

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Constructor2()
        {
            var union = new SqlQueries.Union();
            union.Add(new SqlQueries.Select("[TestDatabase].[Dbo].[Customers]").Columns("City"));
            union.Selects.Add(new SqlQueries.Select("[TestDatabase].[Dbo].[Suppliers]").Columns("City"));
            string statement = union.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        //[TestMethod]
        //public void Properties()
        //{
        //    string statement = (new SqlQueries.Union
        //    {
        //        Table = "TestDatabase.Dbo.Customers"
        //    }).ToString(DbConnectionType);

        //    Assert.AreEqual(Expected, statement);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(QueryBuilderException))]
        //public void Properties2()
        //{
        //    string statement = (new SqlQueries.Union
        //    {
        //        Table = null
        //    }).ToString(DbConnectionType);

        //}
        //[TestMethod]
        //public void Fluent()
        //{
        //    string statement = new SqlQueries.Union().Table("TestDatabase.Dbo.Customers").ToString(DbConnectionType);

        //    Assert.AreEqual(Expected, statement);
        //}

    }
}
