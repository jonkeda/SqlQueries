using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IWhere : IConditionContainer
    {
        ConditionCollection Where { get; }
    }

    public interface IConditions : IConditionContainer
    {
        ConditionCollection Conditions { get; }
    }

}