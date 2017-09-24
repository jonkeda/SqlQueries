using System;
using System.Text;
using SqlQueries.Exceptions;
using SqlQueries.Parts;

namespace SqlQueries.Statements
{
    public abstract class SqlBuilder
    {
        protected SqlBuilder(Type connectionType)
        {
            ConnectionType = connectionType;
        }

        private readonly StringBuilder _sb = new StringBuilder();
        private int _count;

        public void Append(string text)
        {
            _sb.Append(text);
        }

        public Type ConnectionType { get; }

        public void AppendParameter(object wvValue)
        {
            _sb.Append("@p");
            _sb.Append(_count);
            _count++;
        }

        #region Statements

        #endregion

        #region Parts

        public abstract void Table(Table table);

        public abstract void Top(Top top);

        public abstract void Joins(JoinCollection joins);

        public virtual void From(TableCollection tables)
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
                    Append(", ");
                }
                Table(table);
            }
        }

        public virtual void Field(Field field)
        {
            field.Write(this);
        }

        public virtual void Distinct(bool distinct)
        {
            if (distinct)
            {
                Append(" DISTINCT");
            }
        }

        public virtual void Columns(ColumnCollection columns)
        {
            if (columns.Count == 0)
            {
                Append("*");
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
                        Append(", ");
                    }
                    Field(column.Field);
                }
            }
        }

        public virtual void OrderBy(OrderByCollection orderBy)
        {
            bool first = true;
            foreach (OrderByField orderByField in orderBy)
            {
                if (first)
                {
                    Append(" ORDER BY ");
                    first = false;
                }
                else
                {
                    Append(", ");
                }
                Field(orderByField.Field);
                if (orderByField.Descending)
                {
                    Append(" DESC");
                }
            }
        }

        public virtual void GroupBy(GroupByCollection groupBy)
        {
            bool first = true;
            foreach (GroupByField groupByField in groupBy)
            {
                if (first)
                {
                    Append(" GROUP BY ");
                    first = false;
                }
                else
                {
                    Append(", ");
                }
                Field(groupByField.Field);
            }
        }



        public virtual void Where(ConditionCollection where)
        {
            Conditions(where, "WHERE");
        }

        public virtual void Having(ConditionCollection having)
        {
            Conditions(having, "HAVING");
        }

        public void Conditions(ConditionCollection conditions, string statement)
        {
            bool first = true;
            foreach (ICondition w in conditions)
            {
                if (first)
                {
                    Append(" ");
                    Append(statement);
                    Append(" ");
                    first = false;
                }
                else
                {
                    if (conditions.AndOr == SqlAndOr.And)
                    {
                        Append(" AND ");
                    }
                    else
                    {
                        Append(" OR ");
                    }
                }
                w.Write(this);
            }
        }

        public void Conditions(ConditionCollection conditions)
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
                        Append(" AND ");
                    }
                    else
                    {
                        Append(" OR ");
                    }
                }
                w.Write(this);
            }
        }

        public void Join(Join @join)
        {
            if (@join.JoinType == JoinType.FullOuter)
            {
                Append(" FULL OUTER JOIN ");
            }
            else if (@join.JoinType == JoinType.Inner)
            {
                Append(" INNER JOIN ");
            }
            else if (@join.JoinType == JoinType.Left)
            {
                Append(" LEFT JOIN ");
            }
            else if (@join.JoinType == JoinType.Right)
            {
                Append(" RIGHT JOIN ");
            }
            Table(@join.Table);
            Conditions(@join.On, "ON");
        }

        #endregion

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}