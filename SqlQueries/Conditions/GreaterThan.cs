using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
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