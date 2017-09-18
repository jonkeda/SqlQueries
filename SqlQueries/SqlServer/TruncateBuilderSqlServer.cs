using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class TruncateBuilderSqlServer : StatementBuilderSqlServer<Truncate>
    {
        protected override string DoCreateSql(Truncate builder)
        {
            SqlBuilder sb = new SqlBuilder();
            sb.Append("TRUNCATE TABLE");
            Table(sb, builder.Table);
            return sb.ToString();
        }
    }
}