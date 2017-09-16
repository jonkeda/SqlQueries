using System;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class QueryBuildersSqlLite : QueryBuilders
    {
        public QueryBuildersSqlLite(Type connectionType)
            : base(connectionType)
        {
            Statements.Register(new TruncateBuilderSqlite());
            Statements.Register(new DeleteBuilderSqlite());
        }
    }
}