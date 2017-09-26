using SqlQueries.Builders.Interfaces;

namespace SqlQueries.Builders.Parts
{
    public class SelectSource : TableSource, ISelect, IAlias
    {
        public SelectSource()
        {
        }
        public SelectSource(Select select, string alias)
        {
            Select = select;
            Alias = alias;
        }

        public Select Select { get; set; }
        public string Alias { get; set; }

        public override void CreateSql(SqlBuilder sb)
        {
            sb.Append("(");
            sb.Select(Select);
            sb.Append(")");
            sb.Append(" AS ");
            sb.Append($"[{Alias}]");
        }
    }
}