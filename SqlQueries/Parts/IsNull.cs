namespace SqlQueries.Parts
{
    public class IsNull : ConditionIsNull, IWhereCondition
    {
        public IsNull()
        {
        }

        public IsNull(Field field) : base(field)
        {
        }
    }
}