namespace SqlQueries.Parts
{
    public class NotEqualToValue : ConditionOnValue
    {
        public NotEqualToValue() : base(SqlOperator.NotEqual)
        {
        }

        public NotEqualToValue(Field field, object value) : base(field, SqlOperator.NotEqual, value)
        {
        }
    }
}