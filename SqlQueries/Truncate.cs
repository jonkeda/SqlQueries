using SqlQueries.Parts;
using SqlQueries.Statements;

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

    }
}