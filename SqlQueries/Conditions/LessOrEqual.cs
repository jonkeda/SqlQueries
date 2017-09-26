using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
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