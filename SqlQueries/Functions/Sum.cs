using SqlQueries.Builders;
using SqlQueries.Builders.Parts;

namespace SqlQueries.Functions
{
    public class Sum : Function
    {
        public Sum(string fullName) : base("SUM", fullName)
        {
        }

        public Sum(string tableName, string fieldName) : this(tableName, fieldName, null)
        {
        }

        public Sum(string tableName, string fieldName, string alias) : base("SUM", tableName, fieldName, alias)
        {
        }

        public static implicit operator Sum(string value)
        {
            return new Sum(value);
        }
    }
}