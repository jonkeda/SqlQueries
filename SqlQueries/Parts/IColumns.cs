using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IColumns : IQueryBuilder, IFieldContainer
    {
        ColumnCollection Columns { get; set; }
    }
}