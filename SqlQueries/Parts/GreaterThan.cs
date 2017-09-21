namespace SqlQueries.Parts
{
    public class GreaterThan : ConditionOnField
    {
        public GreaterThan()
        {
        }

        public GreaterThan(Field field, Field toField) : base(field, SqlOperator.GreaterThan, toField)
        {
        }
    }
}