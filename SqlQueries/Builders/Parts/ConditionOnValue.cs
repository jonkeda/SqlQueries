using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class ConditionOnValue : ConditionOperator
    {
        public object Value { get; set; }

        public ConditionOnValue(SqlOperator sqlOperator) : base(sqlOperator)
        {
        }

        public ConditionOnValue(Field field, SqlOperator sqlOperator, object value) : base(field, sqlOperator)
        {
            Value = value;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            AppendOperator(sb, Operator);
            sb.AppendParameter(Value);
        }
    }
}