using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface ITable : IQueryBuilder
    {
        Table Table { get; set; }
    }
}
