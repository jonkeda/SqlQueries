using System;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class SelectBuilderSqliteServer : StatementBuilderSqlite<Select>
    {
        public SelectBuilderSqliteServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Select builder)
        {
            sb.Append("SELECT");
            
            Distinct(sb, builder.Distinct);
            sb.Append(" ");
            Columns(sb, builder.Columns);
            sb.Append(" FROM ");
            From(sb, builder.From);
            Joins(sb, builder.Joins);
            Where(sb, builder.Where);
            GroupBy(sb, builder.GroupBy);
            Having(sb, builder.Having);
            OrderBy(sb, builder.OrderBy);
            Top(sb, builder.Top);
            return sb.ToString();
        }
    }
}