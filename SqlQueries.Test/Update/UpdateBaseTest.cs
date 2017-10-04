using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Update
{
    [TestClass]
    public abstract class UpdateBaseTest : BaseTest
    {
        protected UpdateBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; } 

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        public override object[] Parameters { get; } = { "Boel Namen", "Nog een naam" };


        [TestMethod]
        public void Constructor()
        {
            string statement = new Srt2.SqlQueries.Update("[TestDatabase].[Dbo].[Customers]").Set("CustomerName", "Boel Namen").Set("ContactName", "Boel Namen").ToString(DbConnectionType); 

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties()
        {
            SqlQueries.Update sql = (new Srt2.SqlQueries.Update
            {
                Table = "[TestDatabase].[Dbo].[Customers]"
            });

            sql.Columns.Add(new UpdateField()
            {
                Field = "CustomerName",
                Value = "Boel Namen"
            });
            sql.Columns.Add(new UpdateField()
            {
                Field = "ContactName",
                Value = "Boel Namen"
            });
            string statement = sql.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Fluent1()
        {
            string statement = new Srt2.SqlQueries.Update().Table("[TestDatabase].[Dbo].[Customers]").Set("CustomerName", "Boel Namen").Set("ContactName", "Boel Namen").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
    }
}
