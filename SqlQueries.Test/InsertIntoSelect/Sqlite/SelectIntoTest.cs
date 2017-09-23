﻿using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Exceptions;

namespace SqlQueries.Test.InsertIntoSelect.Sqlite
{
    [TestClass]
    public class InsertIntoSelectTest : InsertIntoSelectBaseTest
    {
        public InsertIntoSelectTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "INSERT INTO [CopyCustomers] ([CustomerName], [ContactName]) SELECT [CustomerName], [ContactName] FROM [Customers]";

        public override string ExpectedStar { get; } = "INSERT INTO [CopyCustomers] SELECT * FROM [Customers]";
    }
}
