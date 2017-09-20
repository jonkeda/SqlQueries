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
            Operand = operand;
        }

        public SqlOperator Operand { get; set; }


        protected void Operator(SqlBuilder sb, SqlOperator sqlOperator)
        {
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    sb.Append(" =");
                    break;
                case SqlOperator.NotEqual:
                    sb.Append(" <>");
                    break;
                case SqlOperator.Greater:
                    sb.Append(" >");
                    break;
                case SqlOperator.GreaterOrEqual:
                    sb.Append(" >=");
                    break;
                case SqlOperator.Less:
                    sb.Append(" <");
                    break;
                case SqlOperator.LessOrEqual:
                    sb.Append(" <=");
                    break;
            }
        }
    }
}