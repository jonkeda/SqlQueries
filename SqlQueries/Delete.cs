using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries
{
    public class Delete : QueryBuilder, IFrom, ITop
    {
        public Delete()
        {
        }

        public Delete(Table tableName)
        {
            From.Add(tableName);
        }

        public Delete(Table tableName, int top) : this(tableName)
        {
            Top = top;
        }

        public Top Top { get; set; }

        public TableCollection From { get; set; } = new TableCollection();
    }
}