using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface IWhere : IQueryBuilder
    {
        WhereCollection Where { get; set; }
    }

    public interface IHaving : IQueryBuilder
    {
        HavingCollection Having { get; set; }
    }
}