using System.Text;

namespace SqlQueries.Sqlite
{
    public class DeleteBuilderSqlite : StatementBuilderSqlite<Delete>
    {
        protected override string DoCreateSql(Delete builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE");
            sb.Append(" FROM");
            Table(sb, builder.Table);
            //if (builder.Top > 0)
            //{
            //    sb.Append($@" LIMIT {builder.Top}");
            //}
            return sb.ToString();
        }
    }
}