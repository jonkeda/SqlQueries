using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IHaving : IQueryBuilder
    {
        ConditionCollection Having { get; set; }
    }
}