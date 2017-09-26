using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface IGroupBy : IFieldContainer
    {
        GroupByCollection GroupBy { get; }
    }

}