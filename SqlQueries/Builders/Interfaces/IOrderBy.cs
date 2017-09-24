using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IOrderBy : IFieldContainer
    {
        OrderByCollection OrderBy { get; }
    }
}