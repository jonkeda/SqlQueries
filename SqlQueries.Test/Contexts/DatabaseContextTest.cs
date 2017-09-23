using System.Data.Entity;
using SqlQueries.EntityFramework.Extensions;
using SQLite.CodeFirst;

namespace SqlQueries.Test.Contexts
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