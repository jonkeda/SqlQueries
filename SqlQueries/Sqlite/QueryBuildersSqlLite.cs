using System;
using SqlQueries.SqlServer;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class QueryBuildersSqlLite : QueryBuilders
    {
        public QueryBuildersSqlLite(Type connectionType)
            : base(connectionType)
        {
            Statements.Register(new SelectBuilderSqliteServer(ConnectionType));
            Statements.Register(new TruncateBuilderSqlite(ConnectionType));
            Statements.Register(new DeleteBuilderSqlite(ConnectionType));

            Statements.Register(new OrBuilderSqlServer(ConnectionType));
            Statements.Register(new AndBuilderSqlServer(ConnectionType));
        }
    }
}