﻿using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class GreaterOrEqualTest : GreaterOrEqualBaseTest
    {
        public GreaterOrEqualTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "SELECT * FROM [TestDatabase].[Dbo].[Customers] WHERE [City] >= @p0 AND [CustomerName] >= [ContactName]";

    }
}