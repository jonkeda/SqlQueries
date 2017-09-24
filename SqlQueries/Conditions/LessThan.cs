using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class LessThan : ConditionOnField
    {
        public LessThan() : base(SqlOperator.LessThan)
        {
        }

        public LessThan(Field field, Field toField) : base(field, SqlOperator.LessThan, toField)
        {
        }
    }
}