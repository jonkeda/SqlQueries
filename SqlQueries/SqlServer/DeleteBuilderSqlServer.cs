using System.Text;

namespace SqlQueries.SqlServer
{
    public class DeleteBuilderSqlServer : StatementBuilderSqlServer<Delete>
    {
        protected override string DoCreateSql(Delete builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE");
            Top(sb, builder.Top);
            sb.Append(" FROM");
            Table(sb, builder.Table);
            return sb.ToString();
        }
    }
}