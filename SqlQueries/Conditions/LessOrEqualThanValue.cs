using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class LessOrEqualThanValue : ConditionOnValue
    {
        public LessOrEqualThanValue() : base(SqlOperator.LessOrEqual)
        {
        }

        public LessOrEqualThanValue(Field field, object value)
            : base(field, SqlOperator.LessOrEqual, value)
        {
        }
    }
}