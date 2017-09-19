namespace SqlQueries.Parts
{
    public class Join
    {
        public Join()
        {
        }

        public Join(Table table, JoinType joinType)
        {
            Table = table;
            JoinType = joinType;
        }

        public Join(Table table, JoinType joinType, Field fromField, Field toField)
        {
            Table = table;
            JoinType = joinType;
            On.Add(new JoinOnField(fromField, toField)); 
        }

        public Table Table { get; set; }

        public JoinType JoinType { get; set; }

        public JoinOnCollection On { get; set; } = new JoinOnCollection();
    }
    
}