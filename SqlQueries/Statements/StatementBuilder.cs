using System;

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
            return CreateSql(CreateSqlBuilder(), queryBuilder);
        }

        public abstract SqlBuilder CreateSqlBuilder();

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
    }
}