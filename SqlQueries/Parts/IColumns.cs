using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IColumns : IQueryBuilder
    {
        ColumnCollection Columns { get; set; }
    }
}