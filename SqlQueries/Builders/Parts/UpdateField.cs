using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class UpdateField
    {
        public UpdateField()
        {
        }

        public UpdateField(Field field, object value)
        {
            Field = field;
            Value = value;
        }

        public Field Field { get; set; }
        public object Value { get; set; }
    }
}