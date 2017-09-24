using SqlQueries.Builders;
using SqlQueries.Builders.Parts;

namespace SqlQueries.Conditions
{
    public class Exists : Condition
    {
        public Select Select { get; set; }

        public Exists()
        {
        }

        public Exists(Select select)
        {
            Select = @select;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Append("EXISTS(");
            Select.CreateSql(sb);
            sb.Append(")");
        }
    }
}