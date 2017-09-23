using System.Data.Entity;

namespace SqlQueries.Test.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("TestDatabase")
        {
            Database.SetInitializer<DatabaseContext>(null);

            Database.CommandTimeout = 300;
        }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

    }
}