using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Test.Base;

namespace Srt2.SqlQueries.Test.Select
{
    public abstract class DistinctBaseTest : BaseTest
    {
        protected DistinctBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Distinct

        public abstract string Expected { get; } //= "SELECT DISTINCT [City] FROM [TestDatabase].[Dbo].[Customers]";

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public void ConstructorDistinct()
        {
            string statement = SelectCustomer().Distinct().Columns("[City]").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesDistinct()
        {
            Srt2.SqlQueries.Select select = new Srt2.SqlQueries.Select
            {
                From = {"[TestDatabase].[Dbo].[Customers]" },
                Columns = {"[City]" },
                Distinct = true
            };

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentDistinct()
        {
            string statement = SelectCustomer().Distinct().Columns("[City]").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
