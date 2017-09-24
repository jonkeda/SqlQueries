using System.Collections.ObjectModel;
using SqlQueries.Builders.Interfaces;
using SqlQueries.Functions;

namespace SqlQueries.Builders.Parts
{
    public class ColumnCollection : Collection<ColumnField>, IFieldCollection
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

        public void AddFields(ColumnCollection fields)
        {
            foreach (ColumnField field in fields)
            {
                Add(field);
            }
        }
    }
}