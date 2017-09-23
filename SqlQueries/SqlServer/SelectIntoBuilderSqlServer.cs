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
            Top(sb, builder.Top);
            Distinct(sb, builder.Distinct);
            Columns(sb, builder.Columns);
            sb.Append(" INTO ");
            Table(sb, builder.Into);
            sb.Append(" FROM ");
            From(sb, builder.From);
            Joins(sb, builder.Joins);
            Where(sb, builder.Where);
            GroupBy(sb, builder.GroupBy);
            Having(sb, builder.Having);
            OrderBy(sb, builder.OrderBy);
            return sb.ToString();
        }
    }
}