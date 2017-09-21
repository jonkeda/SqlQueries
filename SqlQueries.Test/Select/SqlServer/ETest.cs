using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class ETest : EBaseTest
    {
        public ETest() : base(typeof(SQLiteConnection))
        {
        }
    }
}