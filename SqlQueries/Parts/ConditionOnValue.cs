using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class ConditionOnValue : ConditionOperator
    {
        public object Value { get; set; }

        public ConditionOnValue()
        {
        }

        public ConditionOnValue(Field field, SqlOperator operand, object value) : base(field, operand)
        {
            Value = value;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            AppendOperator(sb, Operator);
            sb.AppendParameter(Value);
        }
    }
}