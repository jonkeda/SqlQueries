using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders
{
    public abstract class TableSource : QueryBuilder
    {
        public static implicit operator TableSource(string value)
        {
            return new Table(value);
        }
    }
}