using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class InsertIntoSelectBuilderSqlServer : StatementBuilderSqlServer<InsertIntoSelect>
    {
        public InsertIntoSelectBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, InsertIntoSelect builder)
        {
            sb.Append("INSERT INTO ");
            Table(sb, builder.Into);
            if (builder.Columns.Count > 0)
            {
                sb.Append(" (");
                Columns(sb, builder.Columns);
                sb.Append(")");
            }
            sb.Append(" ");
            builder.Select.CreateSql(sb);
            return sb.ToString();

        }
    }
}