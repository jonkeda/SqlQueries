namespace SqlQueries.Parts
{
    public interface IWhere : IConditionContainer
    {
        ConditionCollection Where { get; }
    }
}