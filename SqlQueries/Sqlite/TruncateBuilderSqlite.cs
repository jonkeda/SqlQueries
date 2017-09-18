using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class TruncateBuilderSqlite : StatementBuilderSqlite<Truncate>
    {
        protected override string DoCreateSql(Truncate builder)
        {
            SqlBuilder sb = new SqlBuilder();
            sb.Append("DELETE");
            sb.Append(" FROM");
            Table(sb, builder.Table);
            return sb.ToString();
        }
    }
}