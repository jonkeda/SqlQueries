using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class DistinctBaseTest : BaseTest
    {
        protected DistinctBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Distinct

        public abstract string DistinctExpected { get; } //= "SELECT DISTINCT [City] FROM [TestDatabase].[Dbo].[Customers]";

        [TestMethod]
        public void ConstructorDistinct()
        {
            string statement = SelectCustomer().Distinct().Columns("[City]").ToString();

            Assert.AreEqual(DistinctExpected, statement);
        }

        [TestMethod]
        public void PropertiesDistinct()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "[TestDatabase].[Dbo].[Customers]",
                Columns = "[City]",
                Distinct = true
            };

            string statement = select.ToString();

            Assert.AreEqual(DistinctExpected, statement);
        }

        [TestMethod]
        public void FluentDistinct()
        {
            string statement = SelectCustomer().Distinct().Columns("[City]").ToString();

            Assert.AreEqual(DistinctExpected, statement);
        }

        #endregion

    }
}
