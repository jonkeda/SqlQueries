namespace SqlQueries.Parts
{
    public class EqualToValue : ConditionOnValue
    {
        public EqualToValue() : base(SqlOperator.Equal)
        {
        }

        public EqualToValue(Field field, object value) : base(field, SqlOperator.Equal, value)
        {
        }
    }
}