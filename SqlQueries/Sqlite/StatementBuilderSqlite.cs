using System;
using SqlQueries.Parts;
using SqlQueries.SqlServer;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public abstract class StatementBuilderSqlite<T> : StatementBuilderSqlServer<T>
        where T : QueryBuilder
    {
        protected override void Top(SqlBuilder sb, Top top)
        {
            throw new NotImplementedException();
            //if (top.TopCount > 0)
            //{
            //    sb.Append($@" TOP ({top.TopCount})");
            //}
        }

        protected override void Table(SqlBuilder sb, Table table)
        {
            sb.Append(" ");
            sb.Append("[");
            sb.Append(table.TableName);
            sb.Append("]");
        }

        //protected override void Field(SqlBuilder sb, Field field)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void Columns(SqlBuilder sb, ColumnCollection top)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void OrderBy(SqlBuilder sb, OrderByCollection top)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void GroupBy(SqlBuilder sb, GroupByCollection top)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void Where(SqlBuilder sb, WhereCollection where)
        //{
        //    throw new NotImplementedException();
        //}
    }
}