using Srt2.SqlQueries.Builders.Interfaces;

namespace Srt2.SqlQueries.Builders.Parts
{
    public abstract class Condition : ICondition
    {
        public abstract void Write(SqlBuilder sb);
    }
}
