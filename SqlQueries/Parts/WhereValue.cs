namespace SqlQueries.Parts
{
    public class WhereValue : Where
    {
        public WhereValue()
        {
        }

        public WhereValue(Field field, object value) : this(field, SqlOperator.Equal, value)
        {
        }

        public WhereValue(Field field, SqlOperator operand, object value) : base(field, operand)
        {
            Value = value;
        }

        public object Value { get; set; }
    }
}