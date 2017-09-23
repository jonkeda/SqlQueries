using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IFieldContainer : IQueryBuilder
    {
        void SetCurrent(IFieldCollection conditions);
        void Add(Field field);
    }
}