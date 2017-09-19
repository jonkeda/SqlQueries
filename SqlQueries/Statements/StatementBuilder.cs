using SqlQueries.Parts;

namespace SqlQueries.Statements
{
    public abstract class StatementBuilder
    {
        public abstract string CreateSql(QueryBuilder queryBuilder);
    }

    public abstract class StatementBuilder<T> : StatementBuilder
        where T : QueryBuilder
    {
        public override string CreateSql(QueryBuilder queryBuilder)
        {
            return DoCreateSql(queryBuilder as T);
        }

        protected abstract string DoCreateSql(T builder);

        protected abstract void Table(SqlBuilder sb, Table table);

        protected abstract void Top(SqlBuilder sb, Top top);

        protected abstract void Columns(SqlBuilder sb, ColumnCollection columns);

        protected abstract void OrderBy(SqlBuilder sb, OrderByCollection orderby);

        protected abstract void Field(SqlBuilder sb, Field field);

        protected abstract void GroupBy(SqlBuilder sb, GroupByCollection groupBy);

        protected void Operator(SqlBuilder sb, SqlOperator sqlOperator)
        {
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    sb.Append(" =");
                    break;
                case SqlOperator.NotEqual:
                    sb.Append(" <>");
                    break;
                case SqlOperator.Greater:
                    sb.Append(" >");
                    break;
                case SqlOperator.GreaterOrEqual:
                    sb.Append(" >=");
                    break;
                case SqlOperator.Less:
                    sb.Append(" <");
                    break;
                case SqlOperator.LessOrEqual:
                    sb.Append(" <=");
                    break;
            }
        }

        protected abstract void Where(SqlBuilder sb, WhereCollection @where);
        protected abstract void Having(SqlBuilder sb, HavingCollection having);
        protected abstract void Joins(SqlBuilder sb, JoinCollection joins);
        protected abstract void From(SqlBuilder sb, TableCollection tables);
    }
}