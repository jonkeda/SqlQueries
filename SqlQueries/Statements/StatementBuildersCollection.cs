using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqlQueries.Statements
{
    public class StatementBuildersCollection : Collection<StatementBuilders>
    {

        public StatementBuilder Get(Type queryBuilderInterfaceType)
        {
            return this.FirstOrDefault(t => t.QueryBuilderInterfaceType == queryBuilderInterfaceType)?.StatementBuilder;
        }

        public void Register<T>(StatementBuilder<T> statementBuilder)
            where T : QueryBuilder
        {
            this.Add(new StatementBuilders(typeof(T), statementBuilder));
        }
    }
}