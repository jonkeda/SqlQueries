using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IGroupBy : IQueryBuilder
    {
        GroupByCollection GroupBy { get; }
    }
}