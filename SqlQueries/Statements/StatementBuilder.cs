using System;
using SqlQueries.Parts;

namespace SqlQueries.Statements
{
    public abstract class StatementBuilder
    {
        protected StatementBuilder(Type connectionType)
        {
            ConnectionType = connectionType;
        }

        public Type ConnectionType { get; }

        public string CreateSql(QueryBuilder queryBuilder)
        {
            return CreateSql(new SqlBuilder(ConnectionType), queryBuilder);
        }
        public abstract string CreateSql(SqlBuilder sb, QueryBuilder queryBuilder);
    }

    public abstract class StatementBuilder<T> : StatementBuilder
        where T : QueryBuilder
    {
        protected StatementBuilder(Type connectionType) : base(connectionType)
        {
        }

        public override string CreateSql(SqlBuilder sb, QueryBuilder queryBuilder)
        {
            return DoCreateSql(sb, queryBuilder as T);
        }

        protected abstract string DoCreateSql(SqlBuilder sb, T builder);

        protected abstract void Table(SqlBuilder sb, Table table);

        protected abstract void Top(SqlBuilder sb, Top top);

        protected abstract void Columns(SqlBuilder sb, ColumnCollection columns);

        protected abstract void OrderBy(SqlBuilder sb, OrderByCollection orderby);

        protected abstract void Field(SqlBuilder sb, Field field);

        protected abstract void GroupBy(SqlBuilder sb, GroupByCollection groupBy);

        protected abstract void Where(SqlBuilder sb, WhereCollection @where);

        protected abstract void Having(SqlBuilder sb, HavingCollection having);

        protected abstract void Joins(SqlBuilder sb, JoinCollection joins);

        protected abstract void From(SqlBuilder sb, TableCollection tables);

        protected abstract void Distinct(SqlBuilder sb, bool distinct);
    }
}