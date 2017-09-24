using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class NotEqual : ConditionOnField
    {
        public NotEqual() : base(SqlOperator.NotEqual)
        {
        }

        public NotEqual(Field field, Field toField) : base(field, SqlOperator.NotEqual, toField)
        {
        }
    }
}