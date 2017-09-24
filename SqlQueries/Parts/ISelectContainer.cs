using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface ISelectContainer : IQueryBuilder
    {
        void SetCurrent(SelectCollection selects);
        void Add(Select select);
    }
}