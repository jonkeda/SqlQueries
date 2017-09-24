using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface IInto : IQueryBuilder
    {
        Table Into { get; set; }
    }
}