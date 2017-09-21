using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IWhere : IQueryBuilder, IConditionContainer
    {
        ConditionCollection Where { get; set; }
    }
}