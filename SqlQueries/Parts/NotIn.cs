using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class NotIn : ConditionField
    {
        public Select Select { get; set; }

        public NotIn()
        {
        }

        public NotIn(Field field, Select select) : base(field)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" NOT IN (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}