using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Srt2.SqlQueries.EntityFramework.Extensions
{
    public static class DbSetExtension
    {
        public static string GetTableName<TEntity>(this DbSet<TEntity> entity)
            where TEntity : class
        {
            Type type = typeof(TEntity);
            TableAttribute tableAttribute = type.GetCustomAttributes(false).OfType<TableAttribute>().FirstOrDefault();
            return tableAttribute == null ? type.Name : tableAttribute.Name;
        }

        public static void DeleteAll<TEntity>(this DbSet<TEntity> entity, Database database)
            where TEntity : class
        {
            string tableName = entity.GetTableName();

            int i;
            do
            {
                i = new Delete(tableName, 500).Execute(database);
            } while (i > 0);
        }
    }
}