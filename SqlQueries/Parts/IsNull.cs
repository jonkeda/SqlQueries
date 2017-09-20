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

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" IS NULL");
        }
    }
}