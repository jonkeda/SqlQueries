﻿using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries
{
    public class Update : QueryBuilder, ITable, IWhere, IUpdates
    {
        public Update()
        {
        }

        public Update(Table tableName)
        {
            Table = tableName;
        }

        public Table Table { get; set; }
        public void SetCurrent(ConditionCollection conditions)
        {
            
        }

        public void Add(ICondition condition)
        {
             Where.Add(condition);
        }

        public ConditionCollection Where { get; } = new ConditionCollection();

        public UpdateFieldCollection Columns { get; } = new UpdateFieldCollection();

        public override void CreateSql(SqlBuilder sb)
        {
            sb.Update(this);
        }
    }
}
