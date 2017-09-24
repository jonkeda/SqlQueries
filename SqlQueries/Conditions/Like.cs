using SqlQueries.Builders;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries.Conditions
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