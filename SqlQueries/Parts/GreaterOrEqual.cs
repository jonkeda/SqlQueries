namespace SqlQueries.Parts
{
    public class GreaterOrEqual : ConditionOnField
    {
        public GreaterOrEqual() : base(SqlOperator.GreaterOrEqual)
        {
        }

        public GreaterOrEqual(Field field, Field toField) : base(field, SqlOperator.GreaterOrEqual, toField)
        {
        }
    }
}