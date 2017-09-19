namespace SqlQueries.Parts
{
    public class JoinOnValue : ConditionOnValue, IJoinOnCondition
    {
        public JoinOnValue()
        {
        }

        public JoinOnValue(Field field, object value) : this(field, SqlOperator.Equal, value)
        {
        }

        public JoinOnValue(Field field, SqlOperator operand, object value) : base(field, operand, value)
        {
        }
    }
}