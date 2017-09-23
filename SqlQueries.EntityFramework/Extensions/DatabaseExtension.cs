using System.Data.Entity;
using SqlQueries.Statements;

namespace SqlQueries.EntityFramework.Extensions
{
    public static class DatabaseExtension
    {
        public static int Execute(this QueryBuilder queryBuilder, Database database)
        {
            string sql = queryBuilder.CreateSql(database.Connection);
            return database.ExecuteSqlCommand(sql);
        }
    }
}