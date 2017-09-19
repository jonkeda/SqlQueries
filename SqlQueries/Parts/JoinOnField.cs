namespace SqlQueries.Parts
{
    public class JoinOnField : ConditionOnField, IJoinOnCondition
    {
        public JoinOnField()
        {
        }

        public JoinOnField(Field fromField, Field toField) : this(fromField, SqlOperator.Equal, toField)
        {
        }

        public JoinOnField(Field fromField, SqlOperator operand, Field toField) : base(fromField, operand, toField)
        {

        }
    }
}