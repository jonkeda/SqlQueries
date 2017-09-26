using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Builders
{
    public class SqlBuilderSqlServer : SqlBuilder
    {
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
}