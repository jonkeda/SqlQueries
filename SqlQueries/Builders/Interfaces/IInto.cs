using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface IInto : IQueryBuilder
    {
        Table Into { get; set; }
    }
}