using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class AverageTest : AverageBaseTest
    {
        public AverageTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT AVG([TotalAmount]), AVG([c].[TotalAmount]), AVG([c].[Price]) AS [p] FROM [Customers] AS [c]";
    }
}