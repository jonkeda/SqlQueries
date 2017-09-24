using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlQueries.Builders
{
    public abstract class QueryBuilder
    {
        public string CreateSql(DbConnection connection)
        {
            return CreateSql(connection.GetType());
        }

        public string CreateSql(Type connectionType)
        {
            SqlBuilder sb = SqlBuilder.Get(connectionType);

            CreateSql(sb);

            return sb.ToString();
        }

        public abstract void CreateSql(SqlBuilder sb);

        public override string ToString()
        {
            return CreateSql(typeof(SqlConnection));
        }

        public string ToString(Type connectionType)
        {
            return CreateSql(connectionType);
        }

    }
}