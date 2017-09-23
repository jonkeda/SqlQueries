using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface ISelect : IQueryBuilder
    {
        Select Select { get; set; }
    }
}