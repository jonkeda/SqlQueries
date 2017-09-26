using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class AndBaseTest : BaseTest
    {
        protected AndBaseTest(Type dbConnectionType) : base(dbConnectionType)
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
            Srt2.SqlQueries.Select select = SelectCustomer();
            And and = new And();

            and.Add(new EqualToValue("City", "Berlin"));
            and.Add(new Equal("CustomerName", "ContactName"));
            select.Where.Add(and);
            string statement = select.ToString(DbConnectionType);
            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new And(new EqualToValue("City", "Berlin"), new Equal("CustomerName", "ContactName")));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .And(new EqualToValue("City", "Berlin"), new Equal("CustomerName", "ContactName"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}
