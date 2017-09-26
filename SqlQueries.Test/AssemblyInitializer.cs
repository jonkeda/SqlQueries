using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Srt2.SqlQueries.Builders;

namespace Srt2.SqlQueries.Test
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