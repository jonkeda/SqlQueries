using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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