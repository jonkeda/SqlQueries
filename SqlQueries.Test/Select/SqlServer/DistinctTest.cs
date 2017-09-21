using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class DistinctTest : DistinctBaseTest
    {
        public DistinctTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string DistinctExpected { get; } = "SELECT DISTINCT [City] FROM [TestDatabase].[Dbo].[Customers]";

    }
}