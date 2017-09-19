namespace SqlQueries.Parts
{
    public class HavingField : ConditionOnField, IHavingCondition
    {
        public HavingField()
        {
        }

        public HavingField(Field field, Field toField) : this(field, SqlOperator.Equal, toField)
        {
        }

        public HavingField(Field field, SqlOperator operand, Field toField) : base(field, operand, toField)
        {

        }
    }
}