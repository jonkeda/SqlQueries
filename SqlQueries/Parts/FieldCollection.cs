using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace SqlQueries.Parts
{
    public class FieldCollection : Collection<Field>
    {
        public FieldCollection()
        {
        }

        public FieldCollection(string fields)
        {
            foreach (Field field in Field.ParseFields(fields))
            {
                Add(field);
            }
        }

        public static implicit operator FieldCollection(string value)
        {
            return new FieldCollection(value);
        }
    }
}