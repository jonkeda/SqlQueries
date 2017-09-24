using SqlQueries.Functions;

namespace SqlQueries.Builders.Parts
{
    public class GroupByField
    {
        public GroupByField()
        {
        }

        public GroupByField(Field field)
        {
            Field = field;
        }

        public Field Field { get; set; }
    }
}