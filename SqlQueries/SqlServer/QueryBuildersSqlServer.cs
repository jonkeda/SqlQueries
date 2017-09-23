using System.Data.SqlClient;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class QueryBuildersSqlServer : QueryBuilders
    {
        public QueryBuildersSqlServer()
            : base(typeof(SqlConnection))
        {
            Statements.Register(new SelectBuilderSqlServer(ConnectionType));
            Statements.Register(new DeleteBuilderSqlServer(ConnectionType));
            Statements.Register(new TruncateBuilderSqlServer(ConnectionType));
            Statements.Register(new OrBuilderSqlServer(ConnectionType));
            Statements.Register(new AndBuilderSqlServer(ConnectionType));
            Statements.Register(new SelectIntoBuilderSqlServer(ConnectionType));
        }
    }
}