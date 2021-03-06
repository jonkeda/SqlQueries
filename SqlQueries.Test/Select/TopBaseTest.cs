﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class TopBaseTest : BaseTest
    {
        protected TopBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Top

        protected abstract string Expected { get; }
        protected abstract string PercentageExpected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public virtual void TestPercentageExpectedSql()
        {
            RunSql(PercentageExpected, null);
        }

        [TestMethod]
        public void ConstructorTop()
        {
            string statement = new Srt2.SqlQueries.Select("TestDatabase.Dbo.Customers", 10).ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesTop()
        {
            string statement = new Srt2.SqlQueries.Select
            {
                From = {"TestDatabase.Dbo.Customers" },
                Top = 10
            }.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void PropertiesTopPercentage()
        {
            string statement = new Srt2.SqlQueries.Select
            {
                From = {"TestDatabase.Dbo.Customers" },
                Top = new Top(10, true)
            }.ToString(DbConnectionType);

            Assert.AreEqual(PercentageExpected, statement);
        }

        [TestMethod]
        public void FluentTop()
        {
            string statement = new Srt2.SqlQueries.Select().From("TestDatabase.Dbo.Customers").Top(10).ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void FluentTopPercentage()
        {
            string statement = new Srt2.SqlQueries.Select().From("TestDatabase.Dbo.Customers").Top(10, true).ToString(DbConnectionType);

            Assert.AreEqual(PercentageExpected, statement);
        }

        #endregion


        [TestMethod]
        public  void Operator()
        {
            Top top = new Top(10, true);

            Assert.AreEqual(10, (int)top);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OperatorArgumentNullException()
        {
            Assert.AreEqual("a.b.c d", (int)((Top)null));
        }
    }
}
