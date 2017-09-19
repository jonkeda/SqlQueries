namespace SqlQueries.Parts
{
    public abstract class ConditionOnField : ConditionField
    {
        public Field ToField { get; set; }

        protected ConditionOnField()
        {
        }

        protected ConditionOnField(Field field, SqlOperator operand, Field toField) : base(field, operand)
        {
            ToField = toField;
        }

        protected ConditionOnField(Field field, Field toField) : this(field, SqlOperator.Equal, toField)
        {
        }
    }
}