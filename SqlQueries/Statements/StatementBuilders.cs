using System;

namespace SqlQueries.Statements
{
    public class StatementBuilders
    {
        public Type QueryBuilderInterfaceType { get; }
        public StatementBuilder StatementBuilder { get; }

        public StatementBuilders(Type queryBuilderInterfaceType, StatementBuilder statementBuilder)
        {
            QueryBuilderInterfaceType = queryBuilderInterfaceType;
            StatementBuilder = statementBuilder;
        }
    }
}