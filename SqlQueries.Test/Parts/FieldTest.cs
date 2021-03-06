﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Test.Parts
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void Constructor1()
        {
            Field table = new Field("c");

            AssertField("", "c", "", table);
        }

        [TestMethod]
        public void Constructor2()
        {
            Field table = new Field("c d");

            AssertField("", "c", "d", table);
        }

        [TestMethod]
        public void Constructor3()
        {
            Field table = new Field("c AS d");

            AssertField("", "c", "d", table);
        }

        [TestMethod]
        public void Constructor4()
        {
            Field table = new Field("a.c");

            AssertField("a", "c", "", table);
        }

        [TestMethod]
        public void Constructor6()
        {
            Field table = new Field("a.c AS d");

            AssertField("a", "c", "d", table);
        }

        [TestMethod]
        public void Constructor7()
        {
            Field table = new Field("a.c d");

            AssertField("a", "c", "d", table);
        }

        [TestMethod]
        public void Constructor8()
        {
            Field table = new Field(null, null, null);

        }
        private static void AssertField(string database, string tableName, string alias, Field table)
        {
            Assert.AreEqual(database, table.TableName);
            Assert.AreEqual(tableName, table.FieldName);
            Assert.AreEqual(alias, table.Alias);
        }

        [TestMethod]
        public void ConstructorFieldCollection()
        {
            FieldCollection c = new FieldCollection();
        }

    }
}
