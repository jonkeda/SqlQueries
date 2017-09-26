using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public abstract class ConditionOperator : ConditionField
    {
        protected ConditionOperator(SqlOperator sqlOperator)
        {
            Operator = sqlOperator;
        }

        protected ConditionOperator(Field field, SqlOperator sqlOperator) : base(field)
        {
            Operator = sqlOperator;
        }

        public SqlOperator Operator { get; set; }


        protected void AppendOperator(SqlBuilder sb, SqlOperator sqlOperator)
        {
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    sb.Append(" = ");
                    break;
                case SqlOperator.NotEqual:
                    sb.Append(" <> ");
                    break;
                case SqlOperator.GreaterThan:
                    sb.Append(" > ");
                    break;
                case SqlOperator.GreaterOrEqual:
                    sb.Append(" >= ");
                    break;
                case SqlOperator.LessThan:
                    sb.Append(" < ");
                    break;
                case SqlOperator.LessOrEqual:
                    sb.Append(" <= ");
                    break;
            }
        }
    }
}