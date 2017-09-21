namespace SqlQueries.Parts
{
    public class LessThan : ConditionOnField
    {
        public LessThan()
        {
        }

        public LessThan(Field field, Field toField) : base(field, SqlOperator.LessThan, toField)
        {
        }
    }
}