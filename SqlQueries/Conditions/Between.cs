using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class Between : ConditionField
    {
        public object FromValue { get; set; }
        public object ToValue { get; set; }

        public Between()
        {
        }

        public Between(Field field, object fromValue, object toValue)
            : base(field)
        {
            FromValue = fromValue;
            ToValue = toValue;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" BETWEEN ");
            sb.AppendParameter(FromValue);
            sb.Append(" AND ");
            sb.AppendParameter(ToValue);
        }
    }
}