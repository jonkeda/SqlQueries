using System.Text.RegularExpressions;
using Srt2.SqlQueries.Builders.Interfaces;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class Table : TableSource, IAlias
    {
        public Table(string fullName)
        {
            FullName = fullName;
            Parse();
        }

        public string FullName { get; }

        public string Database { get; private set; }
        public string Schema { get; private set; }
        public string TableName { get; private set; }
        public string Alias { get; private set; }

        private static Regex _parse = new Regex(@"(?:\[?(\w*)\]?\s*[.])?\s*(?:\[?(\w*)\]?\s*[.])?\s*\[?(\w+)\]?\s*(?:AS)?\s*\[?(\w*)\]?",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private void Parse()
        {
            Match match = _parse.Match(FullName);

            Database = match.Groups[1].Value;
            Schema = match.Groups[2].Value;
            TableName = match.Groups[3].Value;
            Alias = match.Groups[4].Value;
        }

        public static implicit operator Table(string value)
        {
            return new Table(value);
        }

        public override void CreateSql(SqlBuilder sb)
        {
            sb.Table(this);
        }
    }
}