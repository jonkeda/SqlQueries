﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Conditions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class GreaterOrEqualBaseTest : BaseTest
    {
        protected GreaterOrEqualBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where

        public abstract string Expected { get; }

        public override object[] Parameters { get; } = { "Berlin" };


        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = SelectCustomer()
                .Where(new GreaterOrEqualThanValue { Field = "City", Value = "Berlin" })
                .Where(new GreaterOrEqual { Field = "CustomerName", ToField = "ContactName" })
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            Srt2.SqlQueries.Select select = SelectCustomer();
            select.Where.Add(new GreaterOrEqualThanValue("City", "Berlin"));
            select.Where.Add(new GreaterOrEqual("CustomerName", "ContactName"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = SelectCustomer()
                .Where()
                .GreaterOrEqualThanValue("City", "Berlin")
                .GreaterOrEqual("CustomerName", "ContactName")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}