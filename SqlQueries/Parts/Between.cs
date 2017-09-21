using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class Between : ConditionField
    {
        public object FromValue { get; set; }
        public object ToValue { get; set; }
        public Field ToField { get; set; }

        public Between()
        {
        }

        public Between(Field field, object fromValue, object toValue)
            : base(field)
        {
            FromValue = fromValue;
            ToValue = toValue;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" BETWEEN ");
            sb.AppendParameter(FromValue);
            sb.Append(" AND ");
            sb.AppendParameter(ToValue);
        }
    }
}