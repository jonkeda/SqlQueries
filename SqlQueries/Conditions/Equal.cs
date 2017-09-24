using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class Equal : ConditionOnField
    {
        public Equal() : base(SqlOperator.Equal)
        {
        }

        public Equal(Field field, Field toField) : base(field, SqlOperator.Equal, toField)
        {
        }
    }
}