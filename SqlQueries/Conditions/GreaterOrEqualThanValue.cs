using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class GreaterOrEqualThanValue : ConditionOnValue
    {
        public GreaterOrEqualThanValue() : base(SqlOperator.GreaterOrEqual)
        {
        }

        public GreaterOrEqualThanValue(Field field, object value)
            : base(field, SqlOperator.GreaterOrEqual, value)
        {
        }
    }
}