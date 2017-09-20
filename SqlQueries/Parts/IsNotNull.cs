using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class IsNotNull : ConditionField
    {
        public IsNotNull()
        {
        }

        public IsNotNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" IS NOT NULL");
        }
    }
}