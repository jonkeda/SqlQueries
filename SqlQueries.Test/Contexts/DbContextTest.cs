using System;
using System.Data.Entity;
using System.Data.SQLite;

namespace Srt2.SqlQueries.Test.Contexts
{
    public class DbContextTest : IDisposable
    {
        private readonly DatabaseContextTest _dossier;

        public DbContextTest()
        {
            _dossier = CreateContext<DatabaseContextTest>();
}

        private T CreateContext<T>()
            where T : DbContext, new()
        {
            T context = new T();
            try
            {
                context.Database.Initialize(true);
            }
            catch (SQLiteException)
            {
            }
            context.Database.Connection.Open();
            return context;
        }

        public void Dispose()
        {
            Dispose(_dossier);
 
            SQLiteConnection.ClearAllPools();
            GC.Collect();
        }

        private void Dispose<T>(T context)
            where T : DbContext, new()
        {
            try
            {
                ((IDbContextTest)context).DeleteAll();
                context.Database.Connection.Close();
                context.Dispose();
            }
            catch
            {
                //
            }
        }
    }
}