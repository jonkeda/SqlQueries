using System;
using SqlQueries.Exceptions;
using SqlQueries.Parts;
using SqlQueries.SqlServer;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class SqlBuilderSqlite : SqlBuilder
    {
        public SqlBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        public override void Top(Top top)
        {
            if (top != null
                && top.TopCount > 0)
            {
                Append($@" LIMIT ({top.TopCount})");

                if (top.Percentage)
                {
                    throw new QueryBuilderNotImplementedForSqliteException("Percentage not implemented for SQLite");
                }
            }
        }

        public override void Table(Table table)
        {
            if (table == null)
            {
                throw new QueryBuilderException("Table is not set");
            }
            Append("[");
            Append(table.TableName);
            Append("]");
            if (!string.IsNullOrEmpty(table.Alias))
            {
                Append(" AS [");
                Append(table.Alias);
                Append("]");
            }
        }

        public override void Joins(JoinCollection joins)
        {
            
            foreach (Join join in joins)
            {
                if (join.JoinType == JoinType.Right
                    || join.JoinType == JoinType.FullOuter)
                {
                    throw new QueryBuilderNotImplementedForSqliteException("Percentage not implemented for SQLite");
                }

                Join(@join);
            }
        }
    }

    public abstract class StatementBuilderSqlite<T> : StatementBuilderSqlServer<T>
        where T : QueryBuilder
    {
        protected StatementBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        public override SqlBuilder CreateSqlBuilder()
        {
            return new SqlBuilderSqlite(ConnectionType);
        }


    }
}