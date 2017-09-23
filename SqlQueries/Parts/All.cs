using System;
using System.Diagnostics;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    [DebuggerDisplay("Field: {Field.FullName} Operator: {Operator} Select: {Select: }")]
    public class All : ConditionOperator
    {
        public Select Select { get; set; }

        public All() : base(SqlOperator.Equal)
        {
        }

        public All(Field field, SqlOperator sqlOperator, Select select) : base(field, sqlOperator)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            AppendOperator(sb, Operator);
            sb.Append("ALL (");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}