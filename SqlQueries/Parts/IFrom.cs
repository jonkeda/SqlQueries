using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IFrom : IQueryBuilder
    {
        TableCollection From { get; }
    }
}