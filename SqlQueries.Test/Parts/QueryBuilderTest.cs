using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Parts
{
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            Srt2.SqlQueries.Select sSelect = new Srt2.SqlQueries.Select("x");

            var x =  sSelect.ToString();
        }

        [TestMethod]
        public void CreateSql1Test()
        {
            Srt2.SqlQueries.Select sSelect = new Srt2.SqlQueries.Select("x");

            sSelect.CreateSql(new SqlConnection());
        }


        [TestMethod]
        public void CreateSql2Test()
        {
            Srt2.SqlQueries.Select sSelect = new Srt2.SqlQueries.Select("x");

            sSelect.CreateSql(typeof(SqlConnection));
        }
    }
}
