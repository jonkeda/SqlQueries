using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class OrderByCollection : Collection<OrderByField>
    {
        public OrderByCollection()
        {
        }

        public OrderByCollection(string fields)
        {
            foreach (Field field in Field.ParseFields(fields))
            {
                Add(new OrderByField(field));
            }
        }

        public static implicit operator OrderByCollection(string value)
        {
            return new OrderByCollection(value);
        }

        public void Add(Field field)
        {
            Add(new OrderByField(field));
        }
    }
}