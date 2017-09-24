using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IColumns : IFieldContainer
    {
        ColumnCollection Columns { get; }
    }
}