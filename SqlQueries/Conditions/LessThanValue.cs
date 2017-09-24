using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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