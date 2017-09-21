namespace SqlQueries.Parts
{
    public class GreaterThanValue : ConditionOnValue
    {
        public GreaterThanValue() : base(SqlOperator.GreaterThan)
        {
        }

        public GreaterThanValue(Field field, object value) 
            : base(field, SqlOperator.GreaterThan, value)
        {
        }
    }
}