using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IJoins : IQueryBuilder
    {
        JoinCollection Joins { get; set; }
    }
}