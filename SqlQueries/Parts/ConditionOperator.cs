using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public abstract class ConditionOperator : ConditionField
    {
        protected ConditionOperator()
        {
        }

        protected ConditionOperator(Field field, SqlOperator operand) : base(field)
        {
            Operator = operand;
        }

        public SqlOperator Operator { get; set; }


        protected void AppendOperator(SqlBuilder sb, SqlOperator sqlOperator)
        {
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    sb.Append(" =");
                    break;
                case SqlOperator.NotEqual:
                    sb.Append(" <>");
                    break;
                case SqlOperator.GreaterThan:
                    sb.Append(" >");
                    break;
                case SqlOperator.GreaterOrEqual:
                    sb.Append(" >=");
                    break;
                case SqlOperator.LessThan:
                    sb.Append(" <");
                    break;
                case SqlOperator.LessOrEqual:
                    sb.Append(" <=");
                    break;
            }
        }
    }
}