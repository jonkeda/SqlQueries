using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
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