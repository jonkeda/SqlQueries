namespace SqlQueries.Builders.Interfaces
{
    public interface ISelect : IQueryBuilder
    {
        Select Select { get; set; }
    }
}