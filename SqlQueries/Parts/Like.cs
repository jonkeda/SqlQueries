﻿using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
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

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            sb.Append(" LIKE ");
            sb.Append($"'{Pattern}'");
        }
    }
}