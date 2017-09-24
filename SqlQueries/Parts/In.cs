using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
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