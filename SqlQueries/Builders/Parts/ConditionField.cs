using SqlQueries.Functions;

namespace SqlQueries.Builders.Parts
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
}