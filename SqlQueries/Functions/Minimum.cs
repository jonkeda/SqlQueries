using SqlQueries.Builders;
using SqlQueries.Builders.Parts;

namespace SqlQueries.Functions
{
    public class Minimum : Function
    {
        public Minimum(string fullName) : base("MIN", fullName)
        {
        }

        public Minimum(string tableName, string fieldName) : this(tableName, fieldName, null)
        {
        }

        public Minimum(string tableName, string fieldName, string alias) : base("MIN", tableName, fieldName, alias)
        {
        }

        public static implicit operator Minimum(string value)
        {
            return new Minimum(value);
        }
    }
}