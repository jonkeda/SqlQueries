using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SqlQueries.Statements
{
    public class QueryBuildersCollection : Collection<QueryBuilders>
    {
        public QueryBuilders Get(Type connectionType)
        {
            return this.FirstOrDefault(t => t.ConnectionType == connectionType);
        }

        public StatementBuilder Get(Type connectionType, Type queryBuilderInterfaceType)
        {
            QueryBuilders queryBuilders = Get(connectionType);
            if (queryBuilders == null)
            {
                throw new QueryBuilderException($@"Query builder not registered for: {connectionType?.FullName}");
            }
            return queryBuilders?.Get(queryBuilderInterfaceType);
        }
    }
}