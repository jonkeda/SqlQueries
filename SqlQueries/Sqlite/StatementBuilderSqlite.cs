using System;
using System.Text;
using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public abstract class StatementBuilderSqlite<T> : StatementBuilder<T>
        where T : QueryBuilder
    {
        protected override void Top(StringBuilder sb, Top top)
        {
            throw new NotImplementedException();
            //if (top.TopCount > 0)
            //{
            //    sb.Append($@" TOP ({top.TopCount})");
            //}
        }

        protected override void Table(StringBuilder sb, Table table)
        {
            sb.Append(" ");
            sb.Append("[");
            sb.Append(table.TableName);
            sb.Append("]");
        }

        protected override void Field(StringBuilder sb, Field field)
        {
            throw new NotImplementedException();
        }

        protected override void Columns(StringBuilder sb, ColumnCollection top)
        {
            throw new NotImplementedException();
        }

        protected override void OrderBy(StringBuilder sb, OrderByCollection top)
        {
            throw new NotImplementedException();
        }
    }
}