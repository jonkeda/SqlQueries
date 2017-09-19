namespace SqlQueries.Parts
{
    public abstract class ConditionField : ICondition
    {
        protected ConditionField()
        {
        }

        protected ConditionField(Field field, SqlOperator operand)
        {
            Field = field;
            Operand = operand;
        }

        public Field Field { get; set; }

        public SqlOperator Operand { get; set; }

    }
}