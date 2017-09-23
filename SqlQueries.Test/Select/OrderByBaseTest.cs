using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class OrderByBaseTest : BaseTest
    {
        protected OrderByBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region OrderBy

        public abstract string Expected { get; } 

        protected override IEnumerable<string> GetExpectedSql()
        {
            yield return Expected;
        }

        [TestMethod]
        public void ConstructorOrderBy()
        {
            string statement = SelectCustomer().OrderByField("CustomerName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesOrderBy()
        {
            SqlQueries.Select select = SelectCustomer();
            select.OrderBy.Add(new OrderByField("CustomerName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentOrderBy()
        {
            string statement = SelectCustomer().OrderByField("CustomerName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
