using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Builders;

namespace SqlQueries.Test
{
    [TestClass]
    public sealed class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            SqlBuilder.Register<SQLiteConnection, SqlBuilderSqlite>();
        }
    }
}