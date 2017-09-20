using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public abstract class ConditionOnValue : ConditionOperator
    {
        public object Value { get; set; }

        protected ConditionOnValue()
        {
        }

        protected ConditionOnValue(Field field, SqlOperator operand, object value) : base(field, operand)
        {
            Value = value;
        }

        protected ConditionOnValue(Field field, object value) : this(field, SqlOperator.Equal, value)
        {
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            Operator(sb, Operand);
            sb.AppendParameter(Value);
        }
    }
}