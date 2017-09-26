using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface IFieldContainer : IQueryBuilder
    {
        void SetCurrent(IFieldCollection conditions);
        void Add(Field field);
    }
}