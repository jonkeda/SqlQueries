using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class GroupByBaseTest : BaseTest
    {
        protected GroupByBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region GroupBy

        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void Constructor1GroupBy()
        {
            string statement = SelectCustomer().GroupBy(new GroupByField {Field = "ContactName"}).ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Constructor2GroupBy()
        {
            Srt2.SqlQueries.Select select = new Srt2.SqlQueries.Select
            {
                From = { "[TestDatabase].[Dbo].[Customers]" },
                GroupBy = { "ContactName" }
            };

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesGroupBy()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.GroupBy.Add(new GroupByField("ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties2GroupBy()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.GroupBy.Add(new Field("ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void FluentGroupBy()
        {
            string statement = SelectCustomer().GroupBy("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void Fluent2GroupBy()
        {
            string statement = SelectCustomer().GroupByField(new Field("ContactName")).ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void OperatorGroupBy()
        {
            GroupByCollection gb = "ContactNaam";
        }

        #endregion

    }
}
