using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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