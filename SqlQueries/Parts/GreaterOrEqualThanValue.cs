namespace SqlQueries.Parts
{
    public class GreaterOrEqualThanValue : ConditionOnValue
    {
        public GreaterOrEqualThanValue() : base(SqlOperator.GreaterOrEqual)
        {
        }

        public GreaterOrEqualThanValue(Field field, object value)
            : base(field, SqlOperator.GreaterOrEqual, value)
        {
        }
    }
}