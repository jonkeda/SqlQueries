using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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