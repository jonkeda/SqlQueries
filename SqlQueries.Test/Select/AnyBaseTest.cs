using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class AnyBaseTest : BaseTest
    {
        protected AnyBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; } //= "SELECT * FROM [DimEmployee] WHERE [LastName] = @p0 AND [Number] > [Count] AND [First] IS NULL AND [Second] IS NOT NULL";

        [TestMethod]
        public void ConstructorWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new Any("Country", SqlOperator.Equal, new SqlQueries.Select("Suppliers", "Country")));

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new Any
            { Field = "Country",
                Operator = SqlOperator.Equal,
                Select =  new SqlQueries.Select("Suppliers", "Country")});

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .Any("Country", SqlOperator.Equal, new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
