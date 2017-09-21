using System;
using SqlQueries.Parts;
using SqlQueries.SqlServer;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public abstract class StatementBuilderSqlite<T> : StatementBuilderSqlServer<T>
        where T : QueryBuilder
    {
        protected StatementBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        protected override void Top(SqlBuilder sb, Top top)
        {
            if (top != null
                && top.TopCount > 0)
            {
                sb.Append($@" LIMIT ({top.TopCount})");
            }
        }

        protected override void Table(SqlBuilder sb, Table table)
        {
            sb.Append(" ");
            sb.Append("[");
            sb.Append(table.TableName);
            sb.Append("]");
        }
    }
}