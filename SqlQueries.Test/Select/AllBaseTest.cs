﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class AllBaseTest : BaseTest
    {
        protected AllBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; } //= "SELECT * FROM [DimEmployee] WHERE [LastName] = @p0 AND [Number] > [Count] AND [First] IS NULL AND [Second] IS NOT NULL";

        protected override string GetExpectedSql()
        {
            return Expected;
        }


        [TestMethod]
        public void ConstructorWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new All("Country", SqlOperator.Equal, new Srt2.SqlQueries.Select("Suppliers", "Country")));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new All
            { Field = "Country",
                Operator = SqlOperator.Equal,
                Select =  new Srt2.SqlQueries.Select("Suppliers", "Country")});

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .All("Country", SqlOperator.Equal, new Srt2.SqlQueries.Select("Suppliers", "Country"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
