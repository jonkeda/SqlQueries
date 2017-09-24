using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class IsNull : ConditionField
    {
        public IsNull()
        {
        }

        public IsNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" IS NULL");
        }
    }
}