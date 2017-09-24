using System;
using SqlQueries.Exceptions;
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
            sb.Top(builder.Top);
            sb.Append(" FROM ");
            sb.From(builder.From);
            sb.Where(builder.Where);
            if (builder.OrderBy.Count > 0)
            {
                throw new QueryBuilderNotImplementedForSqlServerException("Delete Order by not implemented.");
            }
            sb.OrderBy(builder.OrderBy);
            return sb.ToString();
        }
    }
}