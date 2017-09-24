using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IConditionContainer : IQueryBuilder
    {
        void SetCurrent(ConditionCollection conditions);
        void Add(ICondition condition);
    }
}