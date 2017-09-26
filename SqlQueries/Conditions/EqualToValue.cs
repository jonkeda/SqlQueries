using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class EqualToValue : ConditionOnValue
    {
        public EqualToValue() : base(SqlOperator.Equal)
        {
        }

        public EqualToValue(Field field, object value) : base(field, SqlOperator.Equal, value)
        {
        }
    }
}