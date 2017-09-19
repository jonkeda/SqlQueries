using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class DeleteBuilderSqlite : StatementBuilderSqlite<Delete>
    {
        protected override string DoCreateSql(Delete builder)
        {
            SqlBuilder sb = new SqlBuilder();
            sb.Append("DELETE");
            sb.Append(" FROM");
            From(sb, builder.From);
            //if (builder.Top > 0)
            //{
            //    sb.Append($@" LIMIT {builder.Top}");
            //}
            return sb.ToString();
        }
    }
}