using System;

namespace SqlQueries.Test.Base
{
    public abstract class BaseTest
    {
        public Type DbConnectionType { get; }

        protected BaseTest(Type dbConnectionType)
        {
            DbConnectionType = dbConnectionType;
        }

        public SqlQueries.Select SelectCustomer()
        {
            return new SqlQueries
                .Select("TestDatabase.Dbo.Customers");
        }

        public SqlQueries.Select SelectCustomerAs()
        {
            return new SqlQueries
                .Select("TestDatabase.Dbo.Customers c");
        }

    }
}
