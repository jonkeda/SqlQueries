using System;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Contexts;

namespace SqlQueries.Test.Base
{
    public abstract class BaseTest
    {
        public Type DbConnectionType { get; }
        public virtual object[] Parameters { get; } = null;

        protected BaseTest(Type dbConnectionType)
        {
            DbConnectionType = dbConnectionType;
        }

        public SqlQueries.Select SelectCustomer()
        {
            return new SqlQueries
                .Select("TestDatabase.Dbo.Customers");
        }

        public SqlQueries.Select SelectCustomerAs()
        {
            return new SqlQueries
                .Select("TestDatabase.Dbo.Customers c");
        }

        public SqlQueries.Select SelectOrder()
        {
            return new SqlQueries
                .Select("TestDatabase.Dbo.Orders");
        }

        public SqlQueries.Select SelectOrderAs()
        {
            return new SqlQueries
                .Select("TestDatabase.Dbo.Orders c");
        }

        protected abstract string GetExpectedSql();

        [TestMethod]
        public virtual void TestExpectedSql()
        {
            RunSql(GetExpectedSql(), Parameters);
        }

        protected void RunSql(string sql, object[] parameters)
        {
            if (DbConnectionType == typeof(SQLiteConnection))
            {
                using (new DbContextTest())
                {
                    int i = 0;
                    using (DatabaseContext ctx = new DatabaseContext())
                    {
                        if (parameters != null)
                        {
                            ctx.Database.ExecuteSqlCommand(sql, parameters);
                        }
                        else
                        {
                            ctx.Database.ExecuteSqlCommand(sql);
                        }
                        i++;
                    }

                }
            }
        }
    }
}
