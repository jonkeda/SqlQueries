namespace SqlQueries.Parts
{
    public interface IWhere : IConditionContainer
    {
        ConditionCollection Where { get; }
    }

    public interface IConditions : IConditionContainer
    {
        ConditionCollection Conditions { get; }
    }

}