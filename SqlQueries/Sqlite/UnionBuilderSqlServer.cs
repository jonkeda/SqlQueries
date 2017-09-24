using System;
using SqlQueries.Statements;

namespace SqlQueries.Sqlite
{
    public class UnionBuilderSqlite : StatementBuilderSqlite<Union>
    {
        public UnionBuilderSqlite(Type connectionType) : base(connectionType)
        {
        }

        protected override string DoCreateSql(SqlBuilder sb, Union builder)
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
                    sb.Append(" UNION ");
                }
                @select.CreateSql(sb);
            }
            return sb.ToString();

        }
    }
}