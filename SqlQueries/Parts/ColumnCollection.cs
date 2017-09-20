using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class ColumnCollection : Collection<ColumnField>
    {
        public ColumnCollection()
        {
        }

        public ColumnCollection(string fields)
        {
            foreach (Field field in Field.ParseFields(fields))
            {
                Add(new ColumnField(field));
            }
        }

        public static implicit operator ColumnCollection(string value)
        {
            return new ColumnCollection(value);
        }

        public void Add(Field field)
        {
            Add(new ColumnField(field));
        }
    }
}