using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IHaving : IQueryBuilder
    {
        HavingCollection Having { get; set; }
    }
}