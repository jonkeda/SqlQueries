using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class LessOrEqual : ConditionOnField
    {
        public LessOrEqual() : base(SqlOperator.LessOrEqual)
        {
        }

        public LessOrEqual(Field field, Field toField) : base(field, SqlOperator.LessOrEqual, toField)
        {
        }
    }
}