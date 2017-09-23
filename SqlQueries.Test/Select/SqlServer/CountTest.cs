using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class CountTest : CountBaseTest
    {
        public CountTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT COUNT(*), COUNT([TotalAmount]), COUNT([c].[TotalAmount]), COUNT([c].[Price]) AS [p] FROM [TestDatabase].[Dbo].[Customers] AS [c]";
    }
}