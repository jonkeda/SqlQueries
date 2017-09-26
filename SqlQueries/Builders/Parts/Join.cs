using SqlQueries.Conditions;
using SqlQueries.Functions;

namespace SqlQueries.Builders.Parts
{
    public class Join
    {
        public Join()
        {
        }

        public Join(TableSource table, JoinType joinType)
        {
            Table = table;
            JoinType = joinType;
        }

        public Join(TableSource table, JoinType joinType, Field fromField, Field toField)
        {
            Table = table;
            JoinType = joinType;
            On.Add(new Equal(fromField, toField)); 
        }

        public TableSource Table { get; set; }

        public JoinType JoinType { get; set; }

        public ConditionCollection On { get; } = new ConditionCollection();
    }
    
}