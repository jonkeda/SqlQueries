using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IJoins : IConditionContainer
    {
        JoinCollection Joins { get; }
    }
}