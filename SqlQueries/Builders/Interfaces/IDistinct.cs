namespace Srt2.SqlQueries.Builders.Interfaces
{
    public interface IDistinct : IQueryBuilder
    {
        bool Distinct { get; set; }
    }
}