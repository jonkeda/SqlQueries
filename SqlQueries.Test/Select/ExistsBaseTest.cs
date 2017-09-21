using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class ExistsBaseTest : BaseTest
    {
        protected ExistsBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }


        #region Where Exist

        public abstract string ExistExpected { get; } //= @"SELECT * FROM [Suppliers] WHERE EXISTS(SELECT [ProductName] FROM [Products])";


        [TestMethod]
        public void ConstructorExist()
        {
            string statement = SelectCustomer()
                .Where(new Exists(new SqlQueries.Select("Orders", "CustomerID")))
                .ToString();

            Assert.AreEqual(ExistExpected, statement);
        }

        [TestMethod]
        public void PropertiesExist()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "[TestDatabase].[Dbo].[Customers]"
            };
            select.Where.Add(new Exists {Select = new SqlQueries.Select("Orders", "CustomerID")});

            string statement = select.ToString();

            Assert.AreEqual(ExistExpected, statement);
        }

        [TestMethod]
        public void FluentExist()
        {
            string statement = SelectCustomer()
                .Exists(new SqlQueries.Select("Orders", "CustomerID"))
                .ToString();

            Assert.AreEqual(ExistExpected, statement);
        }

        #endregion
    }
}
