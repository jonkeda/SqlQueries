using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Conditions;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class OrBaseTest : BaseTest
    {
        protected OrBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; }
        public override object[] Parameters { get; } = { "Berlin" };

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            Or or = new Or();

            or.Add(new EqualToValue("City", "Berlin"));
            or.Add(new Equal("CustomerName", "ContactName"));
            select.Where.Add(or);
            string statement =  select.ToString(DbConnectionType);
            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new Or(new EqualToValue("City", "Berlin"), new Equal("CustomerName", "ContactName")));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Or(new EqualToValue("City", "Berlin"), new Equal("CustomerName", "ContactName"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}
