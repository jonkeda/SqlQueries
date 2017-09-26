using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class Equal : ConditionOnField
    {
        public Equal() : base(SqlOperator.Equal)
        {
        }

        public Equal(Field field, Field toField) : base(field, SqlOperator.Equal, toField)
        {
        }
    }
}