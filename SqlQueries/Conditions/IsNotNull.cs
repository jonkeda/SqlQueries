using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
{
    public class IsNotNull : ConditionField
    {
        public IsNotNull()
        {
        }

        public IsNotNull(Field field) : base(field)
        {
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" IS NOT NULL");
        }
    }
}