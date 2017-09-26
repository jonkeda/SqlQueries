using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface ITop : IQueryBuilder
    {
        Top Top { get; set; }
    }
}