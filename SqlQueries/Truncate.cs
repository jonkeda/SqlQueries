using SqlQueries.Builders;
using SqlQueries.Builders.Interfaces;
using SqlQueries.Builders.Parts;

namespace SqlQueries
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