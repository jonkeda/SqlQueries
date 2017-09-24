using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class TruncateBuilderSqlServer : StatementBuilderSqlServer<Truncate>
    {
        public TruncateBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Truncate builder)
        {
            sb.Append("TRUNCATE TABLE ");
            sb.Table(builder.Table);
            return sb.ToString();
        }
    }
}