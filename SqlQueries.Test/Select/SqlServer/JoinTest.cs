using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class JoinTest : JoinBaseTest
    {
        public JoinTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] AS [c] INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";

        public override string ExpectedAndOr { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] AS [c] INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID] OR [c].[CustomerID] = [o].[CustomerID]";

        public override string ExpectedInner { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] AS [c] INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedRight { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] AS [c] RIGHT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedLeft { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] AS [c] LEFT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";
        public override string ExpectedFullOuter { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] AS [c] FULL OUTER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]";

    }
}