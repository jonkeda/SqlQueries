using System;
using SqlQueries.Test.Base;

namespace SqlQueries.Test.Select
{
    public abstract class EBaseTest : BaseTest
    {
        protected EBaseTest(Type dbConnectionType) : base(dbConnectionType)
        {
        }
    }
}
