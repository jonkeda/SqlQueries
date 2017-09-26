using System.Data.Entity;
using SQLite.CodeFirst;
using Srt2.SqlQueries.EntityFramework.Extensions;

namespace Srt2.SqlQueries.Test.Contexts
{
    public class DatabaseContextTest : DatabaseContext, IDbContextTest
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SqliteCreateDatabaseIfNotExists<DatabaseContextTest> sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DatabaseContextTest>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public void DeleteAll()
        {
            Customers.DeleteAll(Database);
            Orders.DeleteAll(Database);
            Suppliers.DeleteAll(Database);
            CopyCustomers.DeleteAll(Database);
        }
    }
}