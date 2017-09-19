using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class DeleteBuilderSqlServer : StatementBuilderSqlServer<Delete>
    {
        protected override string DoCreateSql(Delete builder)
        {
            SqlBuilder sb = new SqlBuilder();
            sb.Append("DELETE");
            Top(sb, builder.Top);
            sb.Append(" FROM");
            From(sb, builder.From);
            return sb.ToString();
        }
    }
}