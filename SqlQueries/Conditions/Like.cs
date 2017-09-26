using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Conditions
{
    public class Like : ConditionField
    {
        public string Pattern { get; set; }

        public Like()
        {
        }

        public Like(Field field, string pattern) 
            : base(field)
        {
            Pattern = pattern;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Field(Field);
            sb.Append(" LIKE ");
            sb.Append($"'{Pattern}'");
        }
    }
}