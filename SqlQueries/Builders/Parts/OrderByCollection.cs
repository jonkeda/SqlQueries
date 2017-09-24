using System.Collections.ObjectModel;
using SqlQueries.Builders.Interfaces;
using SqlQueries.Functions;

namespace SqlQueries.Builders.Parts
{
    public class OrderByCollection : Collection<OrderByField>, IFieldCollection
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