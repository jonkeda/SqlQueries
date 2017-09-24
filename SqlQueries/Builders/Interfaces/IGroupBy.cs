using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IGroupBy : IFieldContainer
    {
        GroupByCollection GroupBy { get; }
    }

}