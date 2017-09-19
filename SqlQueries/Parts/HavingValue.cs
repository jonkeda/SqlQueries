namespace SqlQueries.Parts
{
    public class HavingValue : ConditionOnValue, IHavingCondition
    {
        public HavingValue()
        {
        }

        public HavingValue(Field field, object value) : this(field, SqlOperator.Equal, value)
        {
        }

        public HavingValue(Field field, SqlOperator operand, object value) : base(field, operand, value)
        {
        }
    }
}