namespace SqlQueries.Parts
{
    public class LessOrEqual : ConditionOnField
    {
        public LessOrEqual()
        {
        }

        public LessOrEqual(Field field, Field toField) : base(field, SqlOperator.LessOrEqual, toField)
        {
        }
    }
}