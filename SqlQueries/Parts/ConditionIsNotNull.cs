using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public abstract class ConditionIsNotNull : ConditionField
    {
        protected ConditionIsNotNull()
        {
        }

        protected ConditionIsNotNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" IS NOT NULL");
        }
    }
}