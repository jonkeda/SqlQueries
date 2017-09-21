using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class GroupByCollection : Collection<GroupByField>, IFieldCollection
    {
        public GroupByCollection()
        {
        }

        public GroupByCollection(string fields)
        {
            foreach (Field field in Field.ParseFields(fields))
            {
                Add(new GroupByField(field));
            }
        }

        public static implicit operator GroupByCollection(string value)
        {
            return new GroupByCollection(value);
        }

        public void Add(Field field)
        {
            Add(new GroupByField(field));
        }
    }
}