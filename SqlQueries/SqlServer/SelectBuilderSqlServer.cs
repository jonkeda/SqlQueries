using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class SelectBuilderSqlServer : StatementBuilderSqlServer<Select>
    {
        public SelectBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Select builder)
        {
            sb.Append("SELECT");
            Top(sb, builder.Top);
            Distinct(sb, builder.Distinct);
            Columns(sb, builder.Columns);
            sb.Append(" FROM");
            From(sb, builder.From);
            Joins(sb, builder.Joins);
            Where(sb, builder.Where);
            OrderBy(sb, builder.OrderBy);
            GroupBy(sb, builder.GroupBy);
            Having(sb, builder.Having);
            return sb.ToString();
        }
    }
}