using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{


    public class ConditionOnField : ConditionOperator
    {
        public Field ToField { get; set; }

        public ConditionOnField(SqlOperator sqlOperator) : base(sqlOperator)
        {
        }

        public ConditionOnField(Field field, SqlOperator sqlOperator, Field toField) : base(field, sqlOperator)
        {
            ToField = toField;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            AppendOperator(sb, Operator);
            sb.Field(ToField);
        }
    }
}