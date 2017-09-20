using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public abstract class ConditionIsNull : ConditionField
    {
        protected ConditionIsNull()
        {
        }

        protected ConditionIsNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" IS NULL");
        }
    }
}