namespace SqlQueries.Parts
{
    public class EqualToValue : ConditionOnValue
    {
        public EqualToValue()
        {
        }

        public EqualToValue(Field field, object value) : base(field, SqlOperator.Equal, value)
        {
        }
    }
}