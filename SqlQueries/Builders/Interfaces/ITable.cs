using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface ITable : IQueryBuilder
    {
        Table Table { get; set; }
    }
}
