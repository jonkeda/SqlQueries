using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class HavingTest : HavingBaseTest
    {
        public HavingTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string HavingExpected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] HAVING [City] = @p0 AND [ContactName] <> [CustomerName]";

    }
}