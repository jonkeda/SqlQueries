using SqlQueries.Functions;

namespace SqlQueries.Builders.Interfaces
{
    public interface IFieldContainer : IQueryBuilder
    {
        void SetCurrent(IFieldCollection conditions);
        void Add(Field field);
    }
}