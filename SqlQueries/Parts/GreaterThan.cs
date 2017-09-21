namespace SqlQueries.Parts
{
    public class GreaterThan : ConditionOnField
    {
        public GreaterThan() : base(SqlOperator.GreaterThan)
        {
        }

        public GreaterThan(Field field, Field toField) : base(field, SqlOperator.GreaterThan, toField)
        {
        }
    }
}