using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class NotEqualToValue : ConditionOnValue
    {
        public NotEqualToValue() : base(SqlOperator.NotEqual)
        {
        }

        public NotEqualToValue(Field field, object value) : base(field, SqlOperator.NotEqual, value)
        {
        }
    }
}