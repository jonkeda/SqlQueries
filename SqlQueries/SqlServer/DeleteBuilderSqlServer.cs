using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class DeleteBuilderSqlServer : StatementBuilderSqlServer<Delete>
    {
        public DeleteBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Delete builder)
        {
            sb.Append("DELETE");
            Top(sb, builder.Top);
            sb.Append(" FROM");
            From(sb, builder.From);
            Where(sb, builder.Where);
            if (builder.OrderBy.Count > 0)
            {
                throw new QueryBuilderNotImplementedForSqlServerException("Delete Order by not implemented.");
            }
            OrderBy(sb, builder.OrderBy);
            return sb.ToString();
        }
    }
}