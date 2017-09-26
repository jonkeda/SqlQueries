using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class LessThan : ConditionOnField
    {
        public LessThan() : base(SqlOperator.LessThan)
        {
        }

        public LessThan(Field field, Field toField) : base(field, SqlOperator.LessThan, toField)
        {
        }
    }
}