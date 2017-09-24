using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Test.Parts
{
    [TestClass]
    public class ColumnFieldTest
    {
        [TestMethod]
        public void Constructor1()
        {
            Field field = new Field("c");
            ColumnField table = new ColumnField
            {
                Field = field
            };

            Assert.AreSame(table.Field, field);
        }
    }
}