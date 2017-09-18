using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class SelectBuilderSqlServer : StatementBuilderSqlServer<Select>
    {
        protected override string DoCreateSql(Select builder)
        {
            SqlBuilder sb = new SqlBuilder();
            sb.Append("SELECT");
            Top(sb, builder.Top);
            Columns(sb, builder.Columns);
            sb.Append(" FROM");
            Table(sb, builder.Table);
            Where(sb, builder.Where);
            OrderBy(sb, builder.OrderBy);
            GroupBy(sb, builder.GroupBy);
            return sb.ToString();
        }
    }
}