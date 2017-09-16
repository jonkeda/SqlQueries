using System.Text;

namespace SqlQueries.SqlServer
{
    public class TruncateBuilderSqlServer : StatementBuilderSqlServer<Truncate>
    {
        protected override string DoCreateSql(Truncate builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TRUNCATE TABLE");
            Table(sb, builder.Table);
            return sb.ToString();
        }
    }
}