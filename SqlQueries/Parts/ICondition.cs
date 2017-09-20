using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface ICondition
    {
        void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter);
    }

    internal interface IConditionContainer
    {
        void SetCurrent(ConditionCollection conditions);
        void Add(Condition condition);
    }

}