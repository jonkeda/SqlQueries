using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface IFrom : IQueryBuilder
    {
        TableSourceCollection From { get; }
    }
}