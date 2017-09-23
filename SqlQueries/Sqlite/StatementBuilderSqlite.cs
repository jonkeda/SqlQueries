using System;
using SqlQueries.Exceptions;
using SqlQueries.Parts;
using SqlQueries.SqlServer;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public abstract class StatementBuilderSqlite<T> : StatementBuilderSqlServer<T>
        where T : QueryBuilder
    {
        protected StatementBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        protected override void Top(SqlBuilder sb, Top top)
        {
            if (top != null
                && top.TopCount > 0)
            {
                sb.Append($@" LIMIT ({top.TopCount})");

                if (top.Percentage)
                {
                    throw new QueryBuilderNotImplementedForSqliteException("Percentage not implemented for SQLite");
                }
            }
        }

        protected override void Table(SqlBuilder sb, Table table)
        {
            if (table == null)
            {
                throw new QueryBuilderException("Table is not set");
            }
            sb.Append("[");
            sb.Append(table.TableName);
            sb.Append("]");
            if (!string.IsNullOrEmpty(table.Alias))
            {
                sb.Append(" AS [");
                sb.Append(table.Alias);
                sb.Append("]");
            }
        }

        protected override void Joins(SqlBuilder sb, JoinCollection joins)
        {
            
            foreach (Join join in joins)
            {
                if (join.JoinType == JoinType.Right
                    || join.JoinType == JoinType.FullOuter)
                {
                    throw new QueryBuilderNotImplementedForSqliteException("Percentage not implemented for SQLite");
                }

                Join(sb, @join);
            }
        }
    }
}