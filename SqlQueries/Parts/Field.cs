using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SqlQueries.Parts
{
    public class Field
    {
        public Field(string fullName)
        {
            FullName = fullName;
            Parse();
        }

        public Field(string tableName, string fieldName, string @alias)
        {
            TableName = tableName;
            FieldName = fieldName;
            Alias = alias;
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

        public static IEnumerable<Field> ParseFields(string fields)
        {
            Match match = _parse.Match(fields);
            while (match.Success)
            {
                yield return new Field(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                match =  match.NextMatch();
            }
        }

        [DebuggerStepThrough]
        public static explicit operator string(Field value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value.FullName;
        }

        public static implicit operator Field(string value)
        {
            return new Field(value);
        }

    }
}