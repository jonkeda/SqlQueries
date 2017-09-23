namespace SqlQueries.Parts
{
    public interface IColumns : IFieldContainer
    {
        ColumnCollection Columns { get; }
    }
}