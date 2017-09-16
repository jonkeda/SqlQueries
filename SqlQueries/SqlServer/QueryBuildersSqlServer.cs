using System.Data.SqlClient;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class QueryBuildersSqlServer : QueryBuilders
    {
        public QueryBuildersSqlServer()
            : base(typeof(SqlConnection))
        {
            Statements.Register(new SelectBuilderSqlServer());
            Statements.Register(new DeleteBuilderSqlServer());
            Statements.Register(new TruncateBuilderSqlServer());
        }
    }
}