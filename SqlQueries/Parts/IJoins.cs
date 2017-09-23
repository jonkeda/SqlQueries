namespace SqlQueries.Parts
{
    public interface IJoins : IConditionContainer
    {
        JoinCollection Joins { get; }
    }
}