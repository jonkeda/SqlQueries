using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public interface ICondition
    {
        void Write(SqlBuilder sb);
    }
}