using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class WhereTest : WhereBaseTest
    {
        public WhereTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string WhereExpected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [City] = @p0 AND [CustomerName] <> [ContactName]";

    }
}