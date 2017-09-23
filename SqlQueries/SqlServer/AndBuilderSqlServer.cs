using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class AndBuilderSqlServer : StatementBuilderSqlServer<And>
    {
        public AndBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, And builder)
        {
            sb.Append("(");
            Conditions(sb, builder.Conditions);
            sb.Append(")");
            return sb.ToString();
        }
    }
}