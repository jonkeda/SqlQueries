using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class In : ConditionField
    {
        public Select Select { get; set; }

        public In()
        {
        }

        public In(Field field, Select select) : base(field)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" IN (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}