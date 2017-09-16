using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries
{
    public class Delete : QueryBuilder, ITable, ITop
    {
        public Delete()
        {
        }

        public Delete(Table tableName)
        {
            Table = tableName;
        }

        public Delete(Table tableName, int top)
        {
            Table = tableName;
            Top = top;
        }

        public Top Top { get; set; }

        public Table Table { get; set; }
    }
}