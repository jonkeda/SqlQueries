using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class OrderByField
    {
        public OrderByField()
        {
        }

        public OrderByField(Field field)
        {
            Field = field;
        }

        public OrderByField(Field field, bool @descending)
        {
            Field = field;
            Descending = @descending;
        }

        public Field Field { get; set; }
        public bool Descending { get; set; }
    }
}