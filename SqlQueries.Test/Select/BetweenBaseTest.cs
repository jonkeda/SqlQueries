using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class BetweenBaseTest : BaseTest
    {
        protected BetweenBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; } //= "SELECT * FROM [DimEmployee] WHERE [LastName] = @p0 AND [Number] > [Count] AND [First] IS NULL AND [Second] IS NOT NULL";

        public override object[] Parameters { get; } =  { "Luxemburg", "Nederland" } ;

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new Between("Country", "Luxemburg", "Nederland"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new Between
            { Field = "Country",
                FromValue = "Luxemburg",
                ToValue = "Nederland"});

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .Between("Country", "Luxemburg", "Nederland")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
