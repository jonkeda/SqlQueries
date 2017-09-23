using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class MaximumTest : MaximumBaseTest
    {
        public MaximumTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT MAX([TotalAmount]), MAX([c].[TotalAmount]), MAX([c].[Price]) AS [p] FROM [Customers] AS [c]";
    }
}