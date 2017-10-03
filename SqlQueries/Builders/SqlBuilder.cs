using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Exceptions;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders
{
    public abstract class SqlBuilder
    {
        private readonly StringBuilder _sb = new StringBuilder();
        private int _count;

        public void Append(string text)
        {
            _sb.Append(text);
        }

        public void AppendParameter(object wvValue)
        {
            _sb.Append("@p");
            _sb.Append(_count);
            _count++;
        }

        #region Statements

        public virtual void Or(Or builder)
        {
            Append("(");
            Conditions(builder.Conditions);
            Append(")");
        }

        public virtual void And(And builder)
        {
            Append("(");
            Conditions(builder.Conditions);
            Append(")");
        }

        public virtual void Delete(Delete builder)
        {
            Append("DELETE");
            Top(builder.Top);
            Append(" FROM ");
            From(builder.From);
            Where(builder.Where);
            if (builder.OrderBy.Count > 0)
            {
                throw new QueryBuilderNotImplementedForSqlServerException("Delete Order by not implemented.");
            }
            OrderBy(builder.OrderBy);
        }

        public virtual void Update(Update builder)
        {
            Append("UPDATE ");

            Table(builder.Table);

            Append(" SET ");
            Updates(builder.Columns);
            Where(builder.Where);
        }

        private void Updates(UpdateFieldCollection columns)
        {
            bool first = true;
            foreach (UpdateField column in columns)
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
                Append(" = ");
                AppendParameter(column.Value);
            }
        }


        public virtual void InsertIntoSelect(InsertIntoSelect builder)
        {
            Append("INSERT INTO ");
            Table(builder.Into);
            if (builder.Columns.Count > 0)
            {
                Append(" (");
                Columns(builder.Columns);
                Append(")");
            }
            Append(" ");
            builder.Select.CreateSql(this);
        }

        public virtual void Select(Select builder)
        {
            Append("SELECT");
            Top(builder.Top);
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
        }

        public virtual void SelectInto(SelectInto builder)
        {
            Append("SELECT");
            Top(builder.Top);
            Distinct(builder.Distinct);
            Append(" ");
            Columns(builder.Columns);
            Append(" INTO ");
            Table(builder.Into);
            Append(" FROM ");
            From(builder.From);
            Joins(builder.Joins);
            Where(builder.Where);
            GroupBy(builder.GroupBy);
            Having(builder.Having);
            OrderBy(builder.OrderBy);
        }

        public virtual void Truncate(Truncate builder)
        {
            Append("TRUNCATE TABLE ");
            Table(builder.Table);
        }

        public virtual void Union(Union builder)
        {
            bool first = true;
            foreach (Select @select in builder.Selects)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    Append(" UNION ");
                }
                @select.CreateSql(this);
            }
        }

        #endregion

        #region Parts

        public virtual void TableSource(TableSource table)
        {
            table.CreateSql(this);
        }

        public abstract void Table(Table table);

        public abstract void Top(Top top);

        public abstract void Joins(JoinCollection joins);

        public virtual void From(TableSourceCollection tables)
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
            TableSource(@join.Table);
            Conditions(@join.On, "ON");
        }

        #endregion

        public override string ToString()
        {
            return _sb.ToString();
        }

        static SqlBuilder()
        {
            Register<SqlConnection, SqlBuilderSqlServer>();
        }

        private static readonly Dictionary<Type, Type> Builders = new Dictionary<Type, Type>();

        public static void Register<TC, T>()
            where TC : DbConnection
            where T : SqlBuilder
        {
            Builders.Add(typeof(TC), typeof(T));

        }

        public static SqlBuilder Get(Type connectionType)
        {
            Type sqlBuilderType = Builders[connectionType];

            return Activator.CreateInstance(sqlBuilderType) as SqlBuilder;
        }
    }
}