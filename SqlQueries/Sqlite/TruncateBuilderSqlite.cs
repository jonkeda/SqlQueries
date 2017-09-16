using System.Text;

namespace SqlQueries.Sqlite
{
    public class TruncateBuilderSqlite : StatementBuilderSqlite<Truncate>
    {
        protected override string DoCreateSql(Truncate builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE");
            sb.Append(" FROM");
            Table(sb, builder.Table);
            return sb.ToString();
        }
    }
}