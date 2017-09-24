using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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