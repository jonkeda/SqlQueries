using SqlQueries.Builders.Parts;

namespace SqlQueries.Builders.Interfaces
{
    public interface ISelectContainer : IQueryBuilder
    {
        void SetCurrent(SelectCollection selects);
        void Add(Select select);
    }
}