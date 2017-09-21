using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IConditionContainer : IQueryBuilder
    {
        void SetCurrent(ConditionCollection conditions);
        void Add(Condition condition);
    }
}