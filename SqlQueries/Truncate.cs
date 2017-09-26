using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries
{
    public class Truncate : QueryBuilder, ITable
    {
        public Truncate()
        {
        }

        public Truncate(Table tableName)
        {
            Table = tableName;
        }

        public Table Table { get; set; }

        public override void CreateSql(SqlBuilder sb)
        {
            sb.Truncate(this);
        }
    }
}