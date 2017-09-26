using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Test.Parts
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