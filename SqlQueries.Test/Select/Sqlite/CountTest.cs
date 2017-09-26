using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class CountTest : CountBaseTest
    {
        public CountTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT COUNT(*), COUNT([TotalAmount]), COUNT([c].[TotalAmount]), COUNT([c].[Price]) AS [p] FROM [Customers] AS [c]";
    }
}