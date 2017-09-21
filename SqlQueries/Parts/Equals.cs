namespace SqlQueries.Parts
{
    public class Equals : ConditionOnField
    {
        public Equals()
        {
        }

        public Equals(Field field, Field toField) : base(field, SqlOperator.Equal, toField)
        {
        }
    }
}