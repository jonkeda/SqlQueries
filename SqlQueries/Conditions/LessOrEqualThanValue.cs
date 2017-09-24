using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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