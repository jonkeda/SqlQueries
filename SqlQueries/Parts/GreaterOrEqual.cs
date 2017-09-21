namespace SqlQueries.Parts
{
    public class GreaterOrEqual : ConditionOnField
    {
        public GreaterOrEqual()
        {
        }

        public GreaterOrEqual(Field field, Field toField) : base(field, SqlOperator.GreaterOrEqual, toField)
        {
        }
    }
}