using System;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class InsertIntoSelectBuilderSqlite : StatementBuilderSqlite<InsertIntoSelect>
    {
        public InsertIntoSelectBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, InsertIntoSelect builder)
        {
            sb.Append("INSERT INTO ");
            sb.Table(builder.Into);
            if (builder.Columns.Count > 0)
            {
                sb.Append(" (");
                sb.Columns(builder.Columns);
                sb.Append(")");
            }
            sb.Append(" ");
            builder.Select.CreateSql(sb);
            return sb.ToString();}
    }
}