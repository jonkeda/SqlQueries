using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IOrderBy : IQueryBuilder
    {
        OrderByCollection OrderBy { get; set; }
    }
}