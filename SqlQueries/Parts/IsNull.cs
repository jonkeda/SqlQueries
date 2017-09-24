using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class IsNull : ConditionField
    {
        public IsNull()
        {
        }

        public IsNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" IS NULL");
        }
    }
}