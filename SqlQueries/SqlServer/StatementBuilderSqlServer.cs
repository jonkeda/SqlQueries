using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public abstract class StatementBuilderSqlServer<T> : StatementBuilder<T>
        where T : QueryBuilder
    {
        protected override void Top(SqlBuilder sb, Top top)
        {
            if (top != null
                && top.TopCount > 0)
            {
                sb.Append($@" TOP ({top.TopCount})");
            }
        }

        protected override void Table(SqlBuilder sb, Table table)
        {
            if (table == null)
            {
                throw new QueryException("Table not set");
            }
            sb.Append(" ");

            if (!string.IsNullOrEmpty(table.Database))
            {
                sb.Append("[");
                sb.Append(table.Database);
                sb.Append("]");
                sb.Append(".");
            }

            if (!string.IsNullOrEmpty(table.Schema))
            {
                sb.Append("[");
                sb.Append(table.Schema);
                sb.Append("]");
                sb.Append(".");
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

        protected override void Field(SqlBuilder sb, Field field)
        {
            sb.Append(" ");

            if (!string.IsNullOrEmpty(field.TableName))
            {
                sb.Append("[");
                sb.Append(field.TableName);
                sb.Append("].");
            }
            sb.Append("[");
            sb.Append(field.FieldName);
            sb.Append("]");
            if (!string.IsNullOrEmpty(field.Alias))
            {
                sb.Append(" AS [");
                sb.Append(field.Alias);
                sb.Append("]");
            }
        }

        protected override void Columns(SqlBuilder sb, ColumnCollection columns)
        {
            if (columns.Count == 0)
            {
                sb.Append(" *");
            }
            bool first = true;
            foreach (ColumnField column in columns)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(",");
                }
                Field(sb, column.Field);
            }
        }

        protected override void OrderBy(SqlBuilder sb, OrderByCollection orderBy)
        {
            bool first = true;
            foreach (OrderByField orderByField in orderBy)
            {
                if (first)
                {
                    sb.Append(" ORDER BY");
                    first = false;
                }
                else
                {
                    sb.Append(",");
                }
                Field(sb, orderByField.Field);
                if (orderByField.Descending)
                {
                    sb.Append(" DESC");
                }
            }
        }

        protected override void GroupBy(SqlBuilder sb, GroupByCollection groupBy)
        {
            bool first = true;
            foreach (GroupByField groupByField in groupBy)
            {
                if (first)
                {
                    sb.Append(" GROUP BY");
                    first = false;
                }
                else
                {
                    sb.Append(",");
                }
                Field(sb, groupByField.Field);
            }
        }


        protected override void Where(SqlBuilder sb, WhereCollection where)
        {
            bool first = true;
            foreach (Where w in where)
            {
                if (first)
                {
                    sb.Append(" WHERE");
                    first = false;
                }
                else
                {
                    sb.Append(" And");
                }
                WhereValue wv;
                WhereField wf;
                if ((wv = w as WhereValue) != null)
                {
                    Where(sb, wv);
                }
                else if ((wf = w as WhereField) != null)
                {
                    Where(sb, wf);
                }
            }
        }

        private void Where(SqlBuilder sb, WhereValue wv)
        {
            Field(sb, wv.Field);
            Operator(sb, wv.Operand);
            sb.AppendParameter(wv.Value);
        }

        private void Where(SqlBuilder sb, WhereField wf)
        {
            Field(sb, wf.Field);
            Operator(sb, wf.Operand);
            Field(sb, wf.ToField);
        }
    }
}