using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlQueries.Statements
{
    public abstract class QueryBuilder
    {
        public string CreateSql(DbConnection connection)
        {
            return CreateSql(connection.GetType());
        }
        public string CreateSql(Type connectionType)
        {
            StatementBuilder statementBuilder = QueryBuilders.Builders.Get(connectionType, GetType());

            return statementBuilder.CreateSql(this);
        }

        public string CreateSql(SqlBuilder sb)
        {
            StatementBuilder statementBuilder = QueryBuilders.Builders.Get(sb.ConnectionType, GetType());

            return statementBuilder.CreateSql(sb, this);
        }

        public override string ToString()
        {
            return CreateSql(typeof(SqlConnection));
        }

        public string ToString(Type type)
        {
            return CreateSql(type);
        }
    }

}