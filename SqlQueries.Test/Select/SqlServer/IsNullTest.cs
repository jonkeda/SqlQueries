﻿using System.Data.SqlClient;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{


    [TestClass]
    public class IsNullTest : IsNullBaseTest
    {
        public IsNullTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = @"SELECT * FROM [Customers] WHERE [Country] IS NULL";

    }
}