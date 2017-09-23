using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Statements;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class JoinTest : JoinBaseTest
    {
        public JoinTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [Customers] AS [c] INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedAndOr { get; } = "SELECT * FROM [Customers] AS [c] INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID] OR [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedInner { get; } = "SELECT * FROM [Customers] AS [c] INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedRight { get; } = "SELECT * FROM [Customers] AS [c] RIGHT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedLeft { get; } = "SELECT * FROM [Customers] AS [c] LEFT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedFullOuter { get; } = "SELECT * FROM [Customers] AS [c] FULL OUTER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestExpectedFullOuter()
        {
            base.TestExpectedFullOuter();
        }

        [TestMethod]
        [ExpectedException(typeof(SQLiteException))]
        public override void TestExpectedRightSql()
        {
            base.TestExpectedRightSql();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentFullOuterJoin()
        {
            base.FluentFullOuterJoin();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentRightJoinOn()
        {
            base.FluentRightJoinOn();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentFullOuterJoinOn()
        {
            base.FluentFullOuterJoinOn();
        }

        [TestMethod]
        [ExpectedException(typeof(QueryBuilderNotImplementedForSqliteException))]
        public override void FluentRightJoin()
        {
            base.FluentRightJoin();
        }
    }

}