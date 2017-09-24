using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class SelectIntoBuilderSqlServer : StatementBuilderSqlServer<SelectInto>
    {
        public SelectIntoBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, SelectInto builder)
        {
            sb.Append("SELECT");
            sb.Top(builder.Top);
            sb.Distinct(builder.Distinct);
            sb.Append(" ");
            sb.Columns(builder.Columns);
            sb.Append(" INTO ");
            sb.Table(builder.Into);
            sb.Append(" FROM ");
            sb.From(builder.From);
            sb.Joins(builder.Joins);
            sb.Where(builder.Where);
            sb.GroupBy(builder.GroupBy);
            sb.Having(builder.Having);
            sb.OrderBy(builder.OrderBy);
            return sb.ToString();
        }
    }
}