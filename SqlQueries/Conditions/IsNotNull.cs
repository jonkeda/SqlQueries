using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class IsNotNull : ConditionField
    {
        public IsNotNull()
        {
        }

        public IsNotNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" IS NOT NULL");
        }
    }
}