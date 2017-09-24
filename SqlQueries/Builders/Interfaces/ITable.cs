using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface ITable : IQueryBuilder
    {
        Table Table { get; set; }
    }
}
