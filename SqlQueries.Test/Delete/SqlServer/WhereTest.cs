﻿using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlQueries.Test.Delete.SqlServer
{
    [TestClass]
    public class WhereTest : WhereBaseTest
    {
        public WhereTest() : base(typeof(SqlConnection))
        {
        }

        public override string Expected { get; } = "DELETE FROM [TestDatabase].[Dbo].[Customers] WHERE [City] = @p0 AND [CustomerName] = [ContactName]";

    }
}