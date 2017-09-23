using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IInto : IQueryBuilder
    {
        Table Into { get; set; }
    }
}