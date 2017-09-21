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

        public abstract string GroupByExpected { get; } // = "SELECT * FROM [TestDatabase].[Dbo].[Customers] GROUP BY [ContactName]";

        [TestMethod]
        public void ConstructorGroupBy()
        {
            string statement = SelectCustomer().GroupBy("ContactName").ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        [TestMethod]
        public void PropertiesGroupBy()
        {
            SqlQueries.Select select = SelectCustomer();
            select.GroupBy.Add(new GroupByField("ContactName"));

            string statement = select.ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        [TestMethod]
        public void FluentGroupBy()
        {
            string statement = SelectCustomer().GroupBy("ContactName").ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        #endregion

    }
}
