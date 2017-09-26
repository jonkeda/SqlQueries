﻿using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Srt2.SqlQueries.Test.Select.Sqlite
{
    [TestClass]
    public class SumTest : SumBaseTest
    {
        public SumTest() : base(typeof(SQLiteConnection))
        {
        }

        public override string Expected { get; } = "SELECT SUM([TotalAmount]), SUM([c].[TotalAmount]), SUM([c].[Price]) AS [p] FROM [Customers] AS [c]";
    }
}