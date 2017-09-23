using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
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
            SqlQueries.Select select = new SqlQueries.Select
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
            SqlQueries.Select select = SelectCustomer();
            select.GroupBy.Add(new GroupByField("ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void Properties2GroupBy()
        {
            SqlQueries.Select select = SelectCustomer();
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
        public void OperatorGroupBy()
        {
            GroupByCollection gb = "ContactNaam";
        }

        #endregion

    }
}
