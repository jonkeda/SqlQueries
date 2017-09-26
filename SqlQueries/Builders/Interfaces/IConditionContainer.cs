using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface IConditionContainer : IQueryBuilder
    {
        void SetCurrent(ConditionCollection conditions);
        void Add(ICondition condition);
    }
}