using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IWhere : IQueryBuilder
    {
        ConditionCollection Where { get; set; }
    }
}