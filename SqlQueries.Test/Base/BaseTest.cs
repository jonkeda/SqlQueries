using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Exceptions;
using Srt2.SqlQueries.Test.Contexts;

namespace Srt2.SqlQueries.Test.Base
{
    public abstract class BaseTest
    {
        public Type DbConnectionType { get; }
        public virtual object[] Parameters { get; } = null;

        protected BaseTest(Type dbConnectionType)
        {
            DbConnectionType = dbConnectionType;
        }

        public Srt2.SqlQueries.Select SelectCustomer()
        {
            return new Srt2.SqlQueries.Select("TestDatabase.Dbo.Customers");
        }

        public Srt2.SqlQueries.Delete DeleteCustomer()
        {
            return new Srt2.SqlQueries.Delete("TestDatabase.Dbo.Customers");
        }

        public Srt2.SqlQueries.Update UpdateCustomer()
        {
            return new Srt2.SqlQueries.Update("TestDatabase.Dbo.Customers");
        }

        public Srt2.SqlQueries.Select SelectCustomerAs()
        {
            return new Srt2.SqlQueries.Select("TestDatabase.Dbo.Customers c");
        }

        public Srt2.SqlQueries.Select SelectOrder()
        {
            return new Srt2.SqlQueries.Select("TestDatabase.Dbo.Orders");
        }

        public Srt2.SqlQueries.Select SelectOrderAs()
        {
            return new Srt2.SqlQueries.Select("TestDatabase.Dbo.Orders c");
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
