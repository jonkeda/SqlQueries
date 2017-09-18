using System.Text;

namespace SqlQueries.SqlServer
{
    public class SelectBuilderSqlServer : StatementBuilderSqlServer<Select>
    {
        protected override string DoCreateSql(Select builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT");
            Top(sb, builder.Top);
            Columns(sb, builder.Columns);
            //sb.Append(" *");
            sb.Append(" FROM");
            Table(sb, builder.Table);
            OrderBy(sb, builder.OrderBy);
            GroupBy(sb, builder.GroupBy);
            return sb.ToString();
        }
    }
}