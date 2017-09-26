using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
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