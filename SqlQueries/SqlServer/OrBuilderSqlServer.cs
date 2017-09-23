using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class OrBuilderSqlServer : StatementBuilderSqlServer<Or>
    {
        public OrBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Or builder)
        {
            sb.Append("(");
            Conditions(sb, builder.Conditions);
            sb.Append(")");
            return sb.ToString();
        }
    }
}