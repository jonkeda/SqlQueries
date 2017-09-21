﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class IsNullBaseTest : BaseTest
    {
        protected IsNullBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }

        #region Where In

        public abstract string Expected { get; } // = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";


        [TestMethod]
        public void ConstructorIsNull()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where(new IsNull("Country"))
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void PropertiesIsNull()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "Customers"
            };
            select.Where.Add(new IsNull { Field = "Country"});

            string statement = select.ToString();

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public void FluentIsNull()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .IsNull("Country")
                .ToString();

            Assert.AreEqual(Expected, statement);
        }

        #endregion

    }
}
