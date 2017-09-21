namespace SqlQueries.Parts
{
    public class Equal : ConditionOnField
    {
        public Equal() : base(SqlOperator.Equal)
        {
        }

        public Equal(Field field, Field toField) : base(field, SqlOperator.Equal, toField)
        {
        }
    }
}