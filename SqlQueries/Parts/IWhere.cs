using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IWhere : IQueryBuilder
    {
        WhereCollection Where { get; set; }
    }
}