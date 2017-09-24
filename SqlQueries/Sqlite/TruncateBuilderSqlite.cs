using System;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class TruncateBuilderSqlite : StatementBuilderSqlite<Truncate>
    {
        public TruncateBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Truncate builder)
        {
            sb.Append("DELETE");
            sb.Append(" FROM ");
            sb.Table(builder.Table);
            return sb.ToString();
        }
    }
}