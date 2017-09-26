using System.Diagnostics.CodeAnalysis;
using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries
{
    public class Or : QueryBuilder, ICondition, IConditions
    {
        public Or()
        {
             
        }

        public Or(Condition condition, params Condition[] conditions)
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

        public ConditionCollection Conditions { get; } = new ConditionCollection() { AndOr = SqlAndOr.Or };
        public override void CreateSql(SqlBuilder sb)
        {
            sb.Or(this);
        }
    }
}