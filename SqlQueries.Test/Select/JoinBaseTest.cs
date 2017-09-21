using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class JoinBaseTest : BaseTest
    {
        protected JoinBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Join

        private const string JoinExpected = "SELECT * FROM [DimEmployee] AS [e] INNER JOIN [DimOrder] AS [o] ON [e].[Id] = [o].[EmployeeId]";

        [TestMethod]
        public void ConstructorJoin()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        [TestMethod]
        public void PropertiesJoin()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e"
            };
            select.Joins.Add(new Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId"));

            string statement = select.ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        [TestMethod]
        public void FluentJoin()
        {
            string statement = new SqlQueries.Select().From("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        #endregion

    }
}
