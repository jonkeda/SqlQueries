namespace SqlQueries.Parts
{
    public class IsNotNull : ConditionIsNotNull, IWhereCondition
    {
        public IsNotNull()
        {
        }

        public IsNotNull(Field field) : base(field)
        {
        }
    }
}