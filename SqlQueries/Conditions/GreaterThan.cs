using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class GreaterThan : ConditionOnField
    {
        public GreaterThan() : base(SqlOperator.GreaterThan)
        {
        }

        public GreaterThan(Field field, Field toField) : base(field, SqlOperator.GreaterThan, toField)
        {
        }
    }
}