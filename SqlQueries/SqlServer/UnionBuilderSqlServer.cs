using System;
using SqlQueries.Statements;

namespace SqlQueries.SqlServer
{
    public class UnionBuilderSqlServer : StatementBuilderSqlServer<Union>
    {
        public UnionBuilderSqlServer(Type connectionType) : base(connectionType)
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