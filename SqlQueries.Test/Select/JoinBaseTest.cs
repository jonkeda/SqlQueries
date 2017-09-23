using System;
using System.Collections.Generic;
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

        private const string Expected = "SELECT * FROM [DimEmployee] AS [e] INNER JOIN [DimOrder] AS [o] ON [e].[Id] = [o].[EmployeeId]";

        protected override IEnumerable<string> GetExpectedSql()
        {
            yield return Expected;
        }

        [TestMethod]
        public void ConstructorJoin()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesJoin()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e"
            };
            select.Joins.Add(new Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId"));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentJoin()
        {
            string statement = new SqlQueries.Select().From("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
