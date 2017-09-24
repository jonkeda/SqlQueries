using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IUnion : IQueryBuilder
    {
        SelectCollection Selects { get; }
    }
}