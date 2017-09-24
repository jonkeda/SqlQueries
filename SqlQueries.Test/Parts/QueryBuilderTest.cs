using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.SqlServer;
using SqlQueries.Statements;

namespace SqlQueries.Test.Parts
{
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            SqlQueries.Select sSelect = new SqlQueries.Select("x");

            var x =  sSelect.ToString();
        }

        [TestMethod]
        public void CreateSql1Test()
        {
            SqlQueries.Select sSelect = new SqlQueries.Select("x");

            sSelect.CreateSql(new SqlConnection());
        }


        [TestMethod]
        public void CreateSql2Test()
        {
            SqlQueries.Select sSelect = new SqlQueries.Select("x");

            sSelect.CreateSql(typeof(SqlConnection));
        }

        [TestMethod]
        public void CreateSql3Test()
        {
            SqlQueries.Select sSelect = new SqlQueries.Select("x");
            SqlBuilder sb = new SqlBuilderSqlServer(typeof(SqlConnection));
            sSelect.CreateSql(sb);
        }

    }
}
