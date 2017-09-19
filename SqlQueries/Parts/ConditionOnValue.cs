namespace SqlQueries.Parts
{
    public abstract class ConditionOnValue : ConditionField
    {
        public object Value { get; set; }

        protected ConditionOnValue()
        {
        }

        protected ConditionOnValue(Field field, SqlOperator operand, object value) : base(field, operand)
        {
            Value = value;
        }

        protected ConditionOnValue(Field field, object value) : this(field, SqlOperator.Equal, value)
        {
        }
    }
}