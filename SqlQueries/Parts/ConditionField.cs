namespace SqlQueries.Parts
{
    public abstract class ConditionField : Condition
    {
        protected ConditionField()
        {
        }

        protected ConditionField(Field field)
        {
            Field = field;
        }

        public Field Field { get; set; }
    }

    public class Equals : ConditionOnField
    {
        public Equals()
        {
        }

        public Equals(Field field, Field toField) : base(field, SqlOperator.Equal, toField)
        {
        }
    }

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