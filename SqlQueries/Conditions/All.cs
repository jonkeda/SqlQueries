using System.Diagnostics;
using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    [DebuggerDisplay("Field: {Field.FullName} Operator: {Operator} Select: {Select: }")]
    public class All : ConditionOperator
    {
        public Select Select { get; set; }

        public All() : base(SqlOperator.Equal)
        {
        }

        public All(Field field, SqlOperator sqlOperator, Select select) : base(field, sqlOperator)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            AppendOperator(sb, Operator);
            sb.Append("ALL (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}