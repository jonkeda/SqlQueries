using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class Any : ConditionOperator
    {
        public Select Select { get; set; }

        public Any() : base(SqlOperator.Equal)
        {
        }

        public Any(Field field, SqlOperator sqlOperator, Select select) : base(field, sqlOperator)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            AppendOperator(sb, Operator);
            sb.Append("ANY (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}