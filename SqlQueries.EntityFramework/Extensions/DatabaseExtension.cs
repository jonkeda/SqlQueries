using System.Data.Entity;
using Srt2.SqlQueries.Builders;

namespace Srt2.SqlQueries.EntityFramework.Extensions
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