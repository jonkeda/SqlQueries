using SqlQueries.Builders.Interfaces;

namespace SqlQueries.Builders.Parts
{
    public abstract class Condition : ICondition
    {
        public abstract void Write(SqlBuilder sb);
    }
}
