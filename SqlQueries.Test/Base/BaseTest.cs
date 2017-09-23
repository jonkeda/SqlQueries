using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Exceptions;
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

        public SqlQueries.Delete DeleteCustomer()
        {
            return new SqlQueries
                .Delete("TestDatabase.Dbo.Customers");
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
            else
            {
                TSql140Parser parser = new TSql140Parser(true, SqlEngineType.Standalone);
                IList<ParseError> errors;
                TSqlFragment result = parser.Parse(new StringReader(sql), out errors);
                ParseError error = errors.FirstOrDefault();
                if (error != null)
                {
                    throw new QueryParseException(error.Message);
                }
            }
        }
    }
}
