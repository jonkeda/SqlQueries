using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public abstract class Condition : ICondition
    {
        public abstract void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter);
    }
}
