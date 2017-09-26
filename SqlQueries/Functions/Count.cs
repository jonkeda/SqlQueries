using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries.Functions
{
    public class Count : Function
    {
        public Count() : base("COUNT", "*")
        {
        }

        public Count(string fullName) : base("COUNT", fullName)
        {
        }

        public Count(string tableName, string fieldName) : this(tableName, fieldName, null)
        {
        }

        public Count(string tableName, string fieldName, string alias) : base("COUNT", tableName, fieldName, alias)
        {
        }

        public static implicit operator Count(string value)
        {
            return new Count(value);
        }
    }
}