using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Test.Contexts;

namespace SqlQueries.Test.Base
{
    public abstract class BaseTest
    {
        public Type DbConnectionType { get; }
        public virtual object[][] Parameters { get; } = null;

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

        protected abstract IEnumerable<string> GetExpectedSql();

        [TestMethod]
        public virtual void TestExpectedSqls()
        {
            if (DbConnectionType == typeof(SQLiteConnection))
            {
                using (new DbContextTest())
                {
                    int i = 0;
                    using (DatabaseContext ctx = new DatabaseContext())
                    {
                        foreach (string sql in GetExpectedSql())
                        {
                            if (Parameters != null)
                            {
                                ctx.Database.ExecuteSqlCommand(sql, Parameters[i]);

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
}
