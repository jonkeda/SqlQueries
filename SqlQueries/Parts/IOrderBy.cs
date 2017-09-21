using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IOrderBy : IQueryBuilder, IFieldContainer
    {
        OrderByCollection OrderBy { get; set; }
    }
}