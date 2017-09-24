using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IHaving : IConditionContainer
    {
        ConditionCollection Having { get; }
    }
}