using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class In : ConditionField, IWhereCondition
    {
        public Select Select { get; set; }

        public In()
        {
        }

        public In(Field field, Select select) : base(field)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" IN (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}