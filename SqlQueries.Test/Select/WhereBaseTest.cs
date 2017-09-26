using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class WhereBaseTest : BaseTest
    {
        protected WhereBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; } //= "SELECT * FROM [DimEmployee] WHERE [LastName] = @p0 AND [Number] > [Count] AND [First] IS NULL AND [Second] IS NOT NULL";
        public override object[] Parameters { get; } = { "Berlin" };

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", SqlOperator.Equal, "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new EqualToValue("City", "Berlin"));
            select.Where.Add(new Equal("CustomerName", "ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", SqlOperator.Equal, "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        [TestMethod]
        public void FluentWhere2()
        {
            string statement = SelectCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }
        #endregion

    }
}
