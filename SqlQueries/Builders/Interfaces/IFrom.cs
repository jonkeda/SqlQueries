using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IFrom : IQueryBuilder
    {
        TableSourceCollection From { get; }
    }
}