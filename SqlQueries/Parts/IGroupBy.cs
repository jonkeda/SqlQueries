namespace SqlQueries.Parts
{
    public interface IGroupBy : IFieldContainer
    {
        GroupByCollection GroupBy { get; }
    }

}