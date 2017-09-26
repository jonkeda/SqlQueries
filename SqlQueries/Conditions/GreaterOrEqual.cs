using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
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