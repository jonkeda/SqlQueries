using System;
using SqlQueries.Exceptions;
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
            Where(sb, builder.Where);
            OrderBy(sb, builder.OrderBy);
            Top(sb, builder.Top);

            if (builder.Top?.TopCount > 0)
            {
                throw new QueryBuilderNotImplementedForSqliteException("Delete TOP not implemented.");
            }

            if (builder.OrderBy.Count > 0)
            {
                throw new QueryBuilderNotImplementedForSqliteException("Delete Order by not implemented.");
            }

            return sb.ToString();
        }
    }
}