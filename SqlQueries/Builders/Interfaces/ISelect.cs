namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface ISelect : IQueryBuilder
    {
        Select Select { get; set; }
    }

    public interface IAlias : IQueryBuilder
    {
        string Alias { get; }
    }

}