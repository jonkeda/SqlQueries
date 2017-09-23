namespace SqlQueries.Parts
{
    public interface IOrderBy : IFieldContainer
    {
        OrderByCollection OrderBy { get; }
    }
}