using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IWhere : IConditionContainer
    {
        ConditionCollection Where { get; set; }
    }
}