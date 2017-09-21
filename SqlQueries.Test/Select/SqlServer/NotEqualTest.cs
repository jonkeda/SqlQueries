﻿using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class NotEqualTest : NotEqualBaseTest
    {
        public NotEqualTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [City] <> @p0 AND [CustomerName] <> [ContactName]";

    }
}