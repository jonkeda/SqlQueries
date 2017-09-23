using System;
using System.Collections.Generic;
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

        protected override IEnumerable<string> GetExpectedSql()
        {
            yield return Expected;
        }

        [TestMethod]
        public void ConstructorGroupBy()
        {
            string statement = SelectCustomer().GroupBy(new GroupByField {Field = "ContactName"}).ToString(DbConnectionType);

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
        public void FluentGroupBy()
        {
            string statement = SelectCustomer().GroupBy("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
