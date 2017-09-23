using System;
using SqlQueries.Exceptions;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class SelectIntoBuilderSqliteServer : StatementBuilderSqlite<SelectInto>
    {
        public SelectIntoBuilderSqliteServer(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, SelectInto builder)
        {
            throw new QueryBuilderNotImplementedForSqliteException("Select Into is not supported by sqlite");
            //sb.Append("SELECT");
            
            //Distinct(sb, builder.Distinct);
            //Columns(sb, builder.Columns);
            //sb.Append(" INTO ");
            //Table(sb, builder.Into);
            //sb.Append(" FROM ");
            //From(sb, builder.From);
            //Joins(sb, builder.Joins);
            //Where(sb, builder.Where);
            //GroupBy(sb, builder.GroupBy);
            //Having(sb, builder.Having);
            //OrderBy(sb, builder.OrderBy);
            //Top(sb, builder.Top);
            //return sb.ToString();
        }
    }
}