using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders
{
    public abstract class TableSource : QueryBuilder
    {
        public static implicit operator TableSource(string value)
        {
            return new Table(value);
        }
    }
}