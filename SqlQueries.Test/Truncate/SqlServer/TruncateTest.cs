﻿using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Truncate.SqlServer
{
    [TestClass]
    public class TruncateTest : TruncateBaseTest
    {
        public TruncateTest() : base(typeof(SqlConnection))
        {
        }

        public override string TruncateExpected { get; } = "TRUNCATE TABLE [TestDatabase].[Dbo].[Customers]";
    }
}
