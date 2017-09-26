using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class ColumnField
    {
        public ColumnField()
        {
        }

        public ColumnField(Field field)
        {
            Field = field;
        }

        public Field Field { get; set; }
    }
}