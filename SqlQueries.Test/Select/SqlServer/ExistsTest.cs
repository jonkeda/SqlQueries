using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ExistsTest : ExistsBaseTest
    {
        public ExistsTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string ExistExpected { get; } = @"SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE EXISTS(SELECT [CustomerID] FROM [Orders])";

    }
}