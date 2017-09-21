using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IHaving : IQueryBuilder, IConditionContainer
    {
        ConditionCollection Having { get; set; }
    }
}