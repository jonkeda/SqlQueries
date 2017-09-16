using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface ITop : IQueryBuilder
    {
        Top Top { get; set; }
    }
}