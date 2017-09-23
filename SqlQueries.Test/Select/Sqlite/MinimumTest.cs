using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class MinimumTest : MinimumBaseTest
    {
        public MinimumTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT MIN([TotalAmount]), MIN([c].[TotalAmount]), MIN([c].[Price]) AS [p] FROM [Customers] AS [c]";
    }
}