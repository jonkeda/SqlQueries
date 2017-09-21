using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IJoins : IQueryBuilder, IConditionContainer
    {
        JoinCollection Joins { get; set; }
    }
}