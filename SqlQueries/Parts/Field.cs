using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public class Field
    {
        public Field(string fullName)
        {
            FullName = fullName;
            Parse();
        }

        public Field(string tableName, string fieldName) : this(tableName, fieldName, null)
        { }

        public Field(string tableName, string fieldName, string alias)
        {
            TableName = tableName?.Trim('[', ']');
            FieldName = fieldName?.Trim('[', ']');
            Alias = alias?.Trim('[', ']');
        }

        public string FullName { get; }

        public string TableName { get; private set; }
        public string FieldName { get; private set; }
        public string Alias { get; private set; }

        internal static Regex _parse = new Regex(@"\s*(?:\[?(\w*)\]?\s*[.])?\s*\[?(\w+|[*])\]?\s*(?:AS)?\s*\[?(\w*)\]?", 
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private void Parse()
        {
            Match match = _parse.Match(FullName);

            TableName = match.Groups[1].Value;
            FieldName = match.Groups[2].Value;
            Alias = match.Groups[3].Value;
        }

        public virtual void Write(SqlBuilder sb)
        {
            sb.Append(" ");

            if (!string.IsNullOrEmpty(TableName))
            {
                sb.Append("[");
                sb.Append(TableName);
                sb.Append("].");
            }
            if (FieldName == "*")
            {
                sb.Append("*");
            }
            else
            {
                sb.Append("[");
                sb.Append(FieldName);
                sb.Append("]");
            }
            if (!string.IsNullOrEmpty(Alias))
            {
                sb.Append(" AS [");
                sb.Append(Alias);
                sb.Append("]");
            }
        }

        public static IEnumerable<Field> ParseFields(string fields)
        {
            Match match = _parse.Match(fields);
            while (match.Success)
            {
                yield return new Field(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                match =  match.NextMatch();
            }
        }

        public static implicit operator Field(string value)
        {
            return new Field(value);
        }
    }
}