namespace SqlQueries.Parts
{
    public class LessThanValue : ConditionOnValue
    {
        public LessThanValue() : base(SqlOperator.LessThan)
        {
        }

        public LessThanValue(Field field, object value)
            : base(field, SqlOperator.LessThan, value)
        {
        }
    }
}