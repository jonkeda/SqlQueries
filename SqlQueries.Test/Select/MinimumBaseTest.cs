﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class MinimumBaseTest : BaseTest
    {
        protected MinimumBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorColumns()
        {
            string statement = SelectCustomerAs()
                .Column(new Minimum("TotalAmount"), new Minimum("c", "TotalAmount"), new Minimum("c", "Price", "p"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            Srt2.SqlQueries.Select select = SelectCustomerAs();
            select.Columns.Add(new Minimum("TotalAmount"));
            select.Columns.Add(new Minimum("c", "TotalAmount"));
            select.Columns.Add(new Minimum("c", "Price", "p"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs().Minimum("TotalAmount")
                .Columns().Minimum("c", "TotalAmount").Minimum("c", "Price", "p")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}