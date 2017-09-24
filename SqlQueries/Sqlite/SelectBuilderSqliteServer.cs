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

            sb.Distinct(builder.Distinct);
            sb.Append(" ");
            sb.Columns(builder.Columns);
            sb.Append(" FROM ");
            sb.From(builder.From);
            sb.Joins(builder.Joins);
            sb.Where(builder.Where);
            sb.GroupBy(builder.GroupBy);
            sb.Having(builder.Having);
            sb.OrderBy(builder.OrderBy);
            sb.Top(builder.Top);
            return sb.ToString();
        }
    }
}