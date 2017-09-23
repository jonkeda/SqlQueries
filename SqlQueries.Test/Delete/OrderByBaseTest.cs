﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Delete
{
    public abstract class OrderByBaseTest : BaseTest
    {
        protected OrderByBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }


        public abstract string Expected { get; }

        protected override string GetExpectedSql()
        {
            return Expected;
        }

        [TestMethod]
        public virtual void ConstructorOrderBy()
        {
            string statement = DeleteCustomer().OrderByField("CustomerName").OrderByFieldDescending("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Constructor2OrderBy()
        {
            SqlQueries.Delete select = new SqlQueries.Delete
            {
                From = { "[TestDatabase].[Dbo].[Customers]" },
                OrderBy = { "CustomerName" }
            };
            select.OrderByFieldDescending("ContactName");
            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Properties1OrderBy()
        {
            SqlQueries.Delete select = DeleteCustomer();
            select.OrderBy.Add(new OrderByField("CustomerName"));
            select.OrderBy.Add(new OrderByField
            {
                Field = "ContactName",
                Descending = true
            });

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Properties2OrderBy()
        {
            SqlQueries.Delete select = DeleteCustomer();
            select.OrderBy.Add(new Field("CustomerName"));
            select.OrderBy.Add(new OrderByField("ContactName", true));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Properties3OrderBy()
        {
            SqlQueries.Delete select = DeleteCustomer();
            select.Add(new Field("CustomerName"));
            select.OrderBy.Add(new OrderByField("ContactName", true));

            string statement = select.ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void FluentOrderBy()
        {
            string statement = DeleteCustomer().OrderByField("CustomerName").OrderByFieldDescending("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }


        [TestMethod]
        public virtual void Fluent2OrderBy()
        {
            string statement = DeleteCustomer().OrderBy("CustomerName").OrderByDescending("ContactName").ToString(DbConnectionType);

            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void Fluent3OrderBy()
        {
            var delete = DeleteCustomer().OrderBy();
            delete.Add(new Field("CustomerName"));
            delete.OrderBy.Add(new OrderByField("ContactName", true));

            string statement = delete.ToString(DbConnectionType);


            Assert.AreEqual(Expected, statement);
        }

        [TestMethod]
        public virtual void OperatorOrderBy()
        {
            OrderByCollection gb = "ContactNaam";
        }

    }
}
