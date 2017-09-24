using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface ITop : IQueryBuilder
    {
        Top Top { get; set; }
    }
}