using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Functions
{
    public class Average : Function
    {
        public Average(string fullName) : base("AVG", fullName)
        {
        }

        public Average(string tableName, string fieldName) : this(tableName, fieldName, null)
        {
        }

        public Average(string tableName, string fieldName, string alias) : base("AVG", tableName, fieldName, alias)
        {
        }

        public static implicit operator Average(string value)
        {
            return new Average(value);
        }
    }
}