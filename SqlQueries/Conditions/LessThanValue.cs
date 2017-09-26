using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class LessThanValue : ConditionOnValue
    {
        public LessThanValue() : base(SqlOperator.LessThan)
        {
        }

        public LessThanValue(Field field, object value)
            : base(field, SqlOperator.LessThan, value)
        {
        }
    }
}