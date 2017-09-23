using System;
using SqlQueries.Exceptions;
using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public abstract class StatementBuilderSqlServer<T> : StatementBuilder<T>
        where T : QueryBuilder
    {
        protected StatementBuilderSqlServer(Type connectionType) : base(connectionType)
        {
        }

        protected override void Top(SqlBuilder sb, Top top)
        {
            if (top != null
                && top.TopCount > 0)
            {
                sb.Append($@" TOP ({top.TopCount})");
                if (top.Percentage)
                {
                    sb.Append($@" PERCENT");
                }
            }
        }

        protected override void From(SqlBuilder sb, TableCollection tables)
        {
            if (tables.Count == 0)
            {
                throw new QueryBuilderException("From not set");
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
                    sb.Append(", ");
                }
                Table(sb, table);
            }
        }


        protected override void Table(SqlBuilder sb, Table table)
        {
            if (table == null)
            {
                throw new QueryBuilderException("Table not set");
            }
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
            field.Write(sb);
        }

        protected override void Distinct(SqlBuilder sb, bool distinct)
        {
            if (distinct)
            {
                sb.Append(" DISTINCT");
            }
        }

        protected override void Columns(SqlBuilder sb, ColumnCollection columns)
        {
            if (columns.Count == 0)
            {
                sb.Append("*");
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
                        sb.Append(", ");
                    }
                    Field(sb, column.Field);
                }
            }
        }

        protected override void OrderBy(SqlBuilder sb, OrderByCollection orderBy)
        {
            bool first = true;
            foreach (OrderByField orderByField in orderBy)
            {
                if (first)
                {
                    sb.Append(" ORDER BY ");
                    first = false;
                }
                else
                {
                    sb.Append(", ");
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
                    sb.Append(" GROUP BY ");
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }
                Field(sb, groupByField.Field);
            }
        }



        protected override void Where(SqlBuilder sb, ConditionCollection where)
        {
            Conditions(sb, where, "WHERE");
        }

        protected override void Having(SqlBuilder sb, ConditionCollection having)
        {
            Conditions(sb, having, "HAVING");
        }

        protected void Conditions(SqlBuilder sb, ConditionCollection conditions, string statement)
        {
            bool first = true;
            foreach (ICondition w in conditions)
            {
                if (first)
                {
                    sb.Append(" ");
                    sb.Append(statement);
                    sb.Append(" ");
                    first = false;
                }
                else
                {
                    if (conditions.AndOr == SqlAndOr.And)
                    {
                        sb.Append(" AND ");
                    }
                    else
                    {
                        sb.Append(" OR ");
                    }
                }
                w.Write(sb, Field);
            }
        }

        protected void Conditions(SqlBuilder sb, ConditionCollection conditions)
        {
            bool first = true;
            foreach (ICondition w in conditions)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    if (conditions.AndOr == SqlAndOr.And)
                    {
                        sb.Append(" AND ");
                    }
                    else
                    {
                        sb.Append(" OR ");
                    }
                }
                w.Write(sb, Field);
            }
        }

        protected override void Joins(SqlBuilder sb, JoinCollection joins)
        {
            foreach (Join join in joins)
            {
                Join(sb, @join);
            }
        }

        protected void Join(SqlBuilder sb, Join @join)
        {
            if (@join.JoinType == JoinType.FullOuter)
            {
                sb.Append(" FULL OUTER JOIN ");
            }
            else if (@join.JoinType == JoinType.Inner)
            {
                sb.Append(" INNER JOIN ");
            }
            else if (@join.JoinType == JoinType.Left)
            {
                sb.Append(" LEFT JOIN ");
            }
            else if (@join.JoinType == JoinType.Right)
            {
                sb.Append(" RIGHT JOIN ");
            }
            Table(sb, @join.Table);
            Conditions(sb, @join.On, "ON");
        }
    }
}