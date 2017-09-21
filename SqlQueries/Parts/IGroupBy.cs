using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IGroupBy : IQueryBuilder, IFieldContainer
    {
        GroupByCollection GroupBy { get; set; }
    }

}