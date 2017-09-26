using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class NotInTest : NotInBaseTest
    {
        public NotInTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE [Country] NOT IN (SELECT [Country] FROM [Suppliers])";

    }
}