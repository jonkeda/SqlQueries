using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Sqlite;
using SqlQueries.Statements;

namespace SqlQueries.Test
{
    [TestClass]
    public sealed class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            QueryBuilders.Builders.Add(new QueryBuildersSqlite(typeof(SQLiteConnection)));
        }
    }
}