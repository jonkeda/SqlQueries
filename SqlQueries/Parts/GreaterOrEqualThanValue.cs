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