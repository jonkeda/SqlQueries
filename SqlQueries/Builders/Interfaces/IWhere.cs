using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
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