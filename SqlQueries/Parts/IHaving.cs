namespace SqlQueries.Parts
{
    public interface IHaving : IConditionContainer
    {
        ConditionCollection Having { get; }
    }
}