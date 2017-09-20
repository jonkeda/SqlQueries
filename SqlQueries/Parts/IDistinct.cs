using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IDistinct : IQueryBuilder
    {
        bool Distinct { get; set; }
    }
}