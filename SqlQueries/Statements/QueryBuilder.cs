using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlQueries.Statements
{
    public abstract class QueryBuilder
    {
        public int ExecuteSqlCommand(DbConnection connection)
        {
            return 0;
            //string sql = CreateSql(connection);
            //if (string.IsNullOrEmpty(sql))
            //{
            //    throw new Exception("No sql statement generated.");
            //}
            //return 0;
            //return connection.ExecuteSqlCommand(sql);
        }

        public string CreateSql(DbConnection connection)
        {
            return CreateSql(connection.GetType());
        }
        public string CreateSql(Type connectionType)
        {
            StatementBuilder statementBuilder = QueryBuilders.Builders.Get(connectionType, GetType());

            return statementBuilder?.CreateSql(this);
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