using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class WhereBaseTest : BaseTest
    {
        protected WhereBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string WhereExpected { get; } //= "SELECT * FROM [DimEmployee] WHERE [LastName] = @p0 AND [Number] > [Count] AND [First] IS NULL AND [Second] IS NOT NULL";

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", SqlOperator.NotEqual, "ContactName")
                .ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new EqualToValue("City", "Berlin"));
            select.Where.Add(new NotEqual("CustomerName", "ContactName"));

            string statement = select.ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where("City", "Berlin")
                .WhereField("CustomerName", SqlOperator.NotEqual, "ContactName")
                .ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        #endregion

    }
}
