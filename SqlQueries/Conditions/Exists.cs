using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Conditions
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