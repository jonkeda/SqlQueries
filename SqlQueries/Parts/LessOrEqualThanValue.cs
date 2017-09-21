namespace SqlQueries.Parts
{
    public class LessOrEqualThanValue : ConditionOnValue
    {
        public LessOrEqualThanValue() : base(SqlOperator.LessOrEqual)
        {
        }

        public LessOrEqualThanValue(Field field, object value)
            : base(field, SqlOperator.LessOrEqual, value)
        {
        }
    }
}