using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class Any : ConditionOperator
    {
        public Select Select { get; set; }

        public Any() : base(SqlOperator.Equal)
        {
        }

        public Any(Field field, SqlOperator sqlOperator, Select select) : base(field, sqlOperator)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            AppendOperator(sb, Operator);
            sb.Append("ANY (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}