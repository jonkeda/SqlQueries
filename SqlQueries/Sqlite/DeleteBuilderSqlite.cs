using System;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class DeleteBuilderSqlite : StatementBuilderSqlite<Delete>
    {
        public DeleteBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Delete builder)
        {
            sb.Append("DELETE");
            sb.Append(" FROM");
            From(sb, builder.From);
            //if (builder.Top > 0)
            //{
            //    sb.Append($@" LIMIT {builder.Top}");
            //}
            return sb.ToString();
        }
    }
}