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

        protected override void From(SqlBuilder sb, TableCollection tables)
        {
            if (tables == null
                || tables.Count == 0)
            {
                return;
            }
            bool first = true;
            foreach (Table table in tables)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(",");
                }
                Table(sb, table);
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
            if (columns == null
                || columns.Count == 0)
            {
                sb.Append(" *");
            }
            else
            {
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
        }

        protected override void OrderBy(SqlBuilder sb, OrderByCollection orderBy)
        {
            if (orderBy == null)
            {
                return;
            }
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
            if (groupBy == null)
            {
                return;
            }
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
            Conditions(sb, where, "WHERE");
        }

        protected override void Having(SqlBuilder sb, HavingCollection having)
        {
            Conditions(sb, having, "HAVING");
        }

        protected void Conditions<TC>(SqlBuilder sb, ConditionCollection<TC> conditions, string statement)
            where TC : ICondition
        {
            if (conditions == null)
            {
                return;
            }
            bool first = true;
            foreach (TC w in conditions)
            {
                if (first)
                {
                    sb.Append(" ");
                    sb.Append(statement);
                    first = false;
                }
                else
                {
                    if (conditions.AndOr == SqlAndOr.And)
                    {
                        sb.Append(" AND");
                    }
                    else
                    {
                        sb.Append(" OR");
                    }
                }
                ConditionOnValue wv;
                ConditionOnField wf;
                if ((wv = w as ConditionOnValue) != null)
                {
                    ConditionOnValue(sb, wv);
                }
                else if ((wf = w as ConditionOnField) != null)
                {
                    ConditionOnField(sb, wf);
                }
            }
        }

        private void ConditionOnValue(SqlBuilder sb, ConditionOnValue wv)
        {
            Field(sb, wv.Field);
            Operator(sb, wv.Operand);
            sb.AppendParameter(wv.Value);
        }

        private void ConditionOnField(SqlBuilder sb, ConditionOnField wf)
        {
            Field(sb, wf.Field);
            Operator(sb, wf.Operand);
            Field(sb, wf.ToField);
        }


        protected override void Joins(SqlBuilder sb, JoinCollection joins)
        {
            if (joins == null)
            {
                return;
            }
            foreach (Join join in joins)
            {
                if (join.JoinType == JoinType.FullOuter)
                {
                    sb.Append(" FULL OUTER JOIN");
                }
                else if (join.JoinType == JoinType.Inner)
                {
                    sb.Append(" INNER JOIN");
                }
                else if (join.JoinType == JoinType.Left)
                {
                    sb.Append(" LEFT JOIN");
                }
                else if (join.JoinType == JoinType.Right)
                {
                    sb.Append(" RIGHT JOIN");
                }
                Table(sb, join.Table);
                Conditions(sb, join.On, "ON");
            }
        }

    }
}