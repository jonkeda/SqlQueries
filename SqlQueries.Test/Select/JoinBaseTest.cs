using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class JoinBaseTest : BaseTest
    {
        protected JoinBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Join

        public abstract string Expected { get; }

        public abstract string ExpectedInner { get; }
        public abstract string ExpectedRight { get; }
        public abstract string ExpectedLeft { get; }
        public abstract string ExpectedFullOuter { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public virtual void TestExpectedInnerSql()
        {
            RunSql(ExpectedInner, Parameters);
        }
        [TestMethod]
        public virtual void TestExpectedRightSql()
        {
            RunSql(ExpectedRight, Parameters);
        }
        [TestMethod]
        public virtual void TestExpectedLeft()
        {
            RunSql(ExpectedLeft, Parameters);
        }
        [TestMethod]
        public virtual void TestExpectedFullOuter()
        {
            RunSql(ExpectedFullOuter, Parameters);
        }

        [TestMethod]
        public void ConstructorJoin()
        {
            string statement = SelectCustomerAs().Join("Orders o", JoinType.Inner, "c.CustomerID", "o.CustomerID").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesJoin()
        {
            SqlQueries.Select select = SelectCustomerAs();
            select.Joins.Add(new Join("Orders o", JoinType.Inner, "c.CustomerID", "o.CustomerID"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentJoin()
        {
            string statement = SelectCustomerAs()
                .Join("Orders o", JoinType.Inner, "c.CustomerID", "o.CustomerID").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentInnerJoin()
        {
            string statement = SelectCustomerAs()
                .InnerJoin("Orders o", "c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedInner, statement);
        }

        [TestMethod]
        public virtual void FluentRightJoin()
        {
            string statement = SelectCustomerAs()
                .RightJoin("Orders o", "c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedRight, statement);
        }
        [TestMethod]
        public void FluentLeftJoin()
        {
            string statement = SelectCustomerAs()
                .LeftJoin("Orders o", "c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedLeft, statement);
        }
        [TestMethod]
        public virtual void FluentFullOuterJoin()
        {
            string statement = SelectCustomerAs()
                .FullOuterJoin("Orders o", "c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedFullOuter, statement);
        }


        [TestMethod]
        public void FluentInnerJoinOn()
        {
            string statement = SelectCustomerAs()
                .InnerJoin("Orders o")
                .Equal("c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedInner, statement);
        }

        [TestMethod]
        public virtual void FluentRightJoinOn()
        {
            string statement = SelectCustomerAs()
                .RightJoin("Orders o")
                .Equal("c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedRight, statement);
        }
        [TestMethod]
        public void FluentLeftJoinOn()
        {
            string statement = SelectCustomerAs()
                .LeftJoin("Orders o")
                .Equal("c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedLeft, statement);
        }
        [TestMethod]
        public virtual void FluentFullOuterJoinOn()
        {
            string statement = SelectCustomerAs()
                .FullOuterJoin("Orders o")
                .Equal("c.CustomerID", "o.CustomerID")
                .ToString(DbConnectionType);

            Assert.AreEqual(ExpectedFullOuter, statement);
        }
        #endregion

    }
}
