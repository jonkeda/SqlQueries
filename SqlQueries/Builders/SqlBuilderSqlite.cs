using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Exceptions;

namespace Srt2.SqlQueries.Builders
{
    public class SqlBuilderSqlite : SqlBuilder
    {

        #region Statements

        public override void Delete(Delete builder)
        {
            Append("DELETE FROM ");
            From(builder.From);
            Where(builder.Where);
            OrderBy(builder.OrderBy);
            Top(builder.Top);

            if (builder.Top?.TopCount > 0)
            {
                throw new QueryBuilderNotImplementedForSqliteException("Delete TOP not implemented.");
            }

            if (builder.OrderBy.Count > 0)
            {
                throw new QueryBuilderNotImplementedForSqliteException("Delete Order by not implemented.");
            }
        }

        public override void Select(Select builder)
        {
            Append("SELECT");
            Distinct(builder.Distinct);
            Append(" ");
            Columns(builder.Columns);
            Append(" FROM ");
            From(builder.From);
            Joins(builder.Joins);
            Where(builder.Where);
            GroupBy(builder.GroupBy);
            Having(builder.Having);
            OrderBy(builder.OrderBy);
            Top(builder.Top);
        }

        public override void SelectInto(SelectInto builder)
        {
            throw new QueryBuilderNotImplementedForSqliteException("Select Into is not supported by sqlite");
        }

        public override void Truncate(Truncate builder)
        {
            Append("DELETE");
            Append(" FROM ");
            Table(builder.Table);
        }

        #endregion

        #region

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

        #endregion
    }
}