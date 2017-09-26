using System.Collections.ObjectModel;

namespace SqlQueries.Builders.Parts
{
    public class TableSourceCollection : Collection<TableSource>
    {

        public TableSourceCollection()
        {
        }

        public TableSourceCollection(Table table)
        {
            Add(table);
        }


        public static implicit operator TableSourceCollection(string value)
        {
            return new TableSourceCollection(new Table(value));
        }
    }
}