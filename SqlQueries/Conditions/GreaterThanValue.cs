using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class GreaterThanValue : ConditionOnValue
    {
        public GreaterThanValue() : base(SqlOperator.GreaterThan)
        {
        }

        public GreaterThanValue(Field field, object value) 
            : base(field, SqlOperator.GreaterThan, value)
        {
        }
    }
}