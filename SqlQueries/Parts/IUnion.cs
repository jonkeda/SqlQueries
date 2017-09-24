using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IUnion : IQueryBuilder
    {
        SelectCollection Selects { get; }
    }
}