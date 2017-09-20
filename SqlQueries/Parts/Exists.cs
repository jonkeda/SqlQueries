using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class Exists : Condition
    {
        public Select Select { get; set; }

        public Exists()
        {
        }

        public Exists(Select select)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            sb.Append(" EXISTS(");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}