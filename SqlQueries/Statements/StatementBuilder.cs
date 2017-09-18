using System.Text;
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


        protected abstract void Table(StringBuilder sb, Table table);

        protected abstract void Top(StringBuilder sb, Top top);

        protected abstract void Columns(StringBuilder sb, ColumnCollection columns);

        protected abstract void OrderBy(StringBuilder sb, OrderByCollection orderby);

        protected abstract void Field(StringBuilder sb, Field field);
        protected abstract void GroupBy(StringBuilder sb, GroupByCollection groupBy);
    }
}