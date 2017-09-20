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
            Operator(sb, Operand);
            sb.AppendParameter(Value);
        }
    }

    public class EqualToValue : ConditionOnValue
    {
        public EqualToValue()
        {
        }

        public EqualToValue(Field field, object value) : base(field, SqlOperator.Equal, value)
        {
        }
    }

    public class GreaterThanValue : ConditionOnValue
    {
        public GreaterThanValue()
        {
        }

        public GreaterThanValue(Field field, object value) : base(field, SqlOperator.GreaterThan, value)
        {
        }
    }

}