using System;
using SqlQueries.Exceptions;
using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class SqlBuilderSqlServer : SqlBuilder
    {
        public SqlBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }


        public override void Top(Top top)
        {
            if (top != null
                && top.TopCount > 0)
            {
                Append($@" TOP ({top.TopCount})");
                if (top.Percentage)
                {
                    Append($@" PERCENT");
                }
            }
        }

        public override void Table(Table table)
        {
            if (table == null)
            {
                throw new QueryBuilderException("Table not set");
            }
            if (!string.IsNullOrEmpty(table.Database))
            {
                Append("[");
                Append(table.Database);
                Append("]");
                Append(".");
            }

            if (!string.IsNullOrEmpty(table.Schema))
            {
                Append("[");
                Append(table.Schema);
                Append("]");
                Append(".");
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
                Join(@join);
            }
        }
    }

    public abstract class StatementBuilderSqlServer<T> : StatementBuilder<T>
        where T : QueryBuilder
    {
        protected StatementBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }


        public override SqlBuilder CreateSqlBuilder()
        {
            return new SqlBuilderSqlServer(ConnectionType);
        }
    }
}