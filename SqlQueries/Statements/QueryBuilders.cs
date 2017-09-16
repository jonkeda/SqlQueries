﻿using System;
using SqlQueries.SqlServer;

namespace SqlQueries.Statements
{
    public class QueryBuilders
    {
        public QueryBuilders(Type connectionType)
        {
            ConnectionType = connectionType;
            Statements = new StatementBuildersCollection();
        }

        public Type ConnectionType { get; }

        public StatementBuildersCollection Statements { get; }

        static QueryBuilders()
        {
            Builders.Add(new QueryBuildersSqlServer());
        }

        public static QueryBuildersCollection Builders { get; } = new QueryBuildersCollection();

        public StatementBuilder Get<T>()
        {
            return Get(typeof(T));
        }
        public StatementBuilder Get(Type builderType)
        {
            var statement = Statements.Get(builderType);
            if (statement == null)
            {
                throw new QueryException($@"Statement builder does not exist for {builderType.Name}");
            }
            return statement;
        }

    }
}
