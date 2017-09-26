using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface ISelectContainer : IQueryBuilder
    {
        void SetCurrent(SelectCollection selects);
        void Add(Select select);
    }
}