﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Functions;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class SumBaseTest : BaseTest
    {
        protected SumBaseTest(Type dbConnectionType) : base(dbConnectionType)
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
                .Column(new Sum("TotalAmount"), new Sum("[c]", "TotalAmount"), new Sum("c", "Price", "p"))
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            Srt2.SqlQueries.Select select = SelectCustomerAs();
            select.Columns.Add(new Sum("TotalAmount"));
            select.Columns.Add(new Sum("[c]", "TotalAmount"));
            select.Columns.Add(new Sum("c", "Price", "p"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = SelectCustomerAs().Sum("TotalAmount")
                .Columns().Sum("[c]", "TotalAmount").Sum("c", "Price", "p")
                .ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

    }
}