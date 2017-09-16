namespace SqlQueries.Parts
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