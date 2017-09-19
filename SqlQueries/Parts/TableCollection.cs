using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class TableCollection : Collection<Table>
    {

        public TableCollection()
        {
        }

        public TableCollection(Table table)
        {
            Add(table);
        }


        public static implicit operator TableCollection(string value)
        {
            return new TableCollection(value);
        }
    }
}