using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class OrderByTest : OrderByBaseTest
    {
        public OrderByTest() : base(typeof(SQLiteConnection))
        {
        }
    }
}