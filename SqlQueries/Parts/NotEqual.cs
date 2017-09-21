namespace SqlQueries.Parts
{
    public class NotEqual : ConditionOnField
    {
        public NotEqual() : base(SqlOperator.NotEqual)
        {
        }

        public NotEqual(Field field, Field toField) : base(field, SqlOperator.NotEqual, toField)
        {
        }
    }
}