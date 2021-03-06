using System.Diagnostics.CodeAnalysis;
using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries
{
    public class And : QueryBuilder, ICondition, IConditions
    {
        public And()
        {

        }

        public And(Condition condition, params Condition[] conditions)
        {
            Conditions.Add(condition);
            foreach (Condition c in conditions)
            {
                Conditions.Add(c);
            }
        }
        public void Write(SqlBuilder sb)
        {
            CreateSql(sb);
        }

        [ExcludeFromCodeCoverage]
        public void SetCurrent(ConditionCollection conditions)
        {

        }

        public void Add(ICondition condition)
        {
            Conditions.Add(condition);
        }

        public ConditionCollection Conditions { get; } = new ConditionCollection();

        public override void CreateSql(SqlBuilder sb)
        {
            sb.And(this);
        }
    }
}