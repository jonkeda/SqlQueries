using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class GreaterOrEqual : ConditionOnField
    {
        public GreaterOrEqual() : base(SqlOperator.GreaterOrEqual)
        {
        }

        public GreaterOrEqual(Field field, Field toField) : base(field, SqlOperator.GreaterOrEqual, toField)
        {
        }
    }
}