namespace SqlQueries.Parts
{
    public class Maximum : Function
    {
        public Maximum(string fullName) : base("MAX", fullName)
        {
        }

        public Maximum(string tableName, string fieldName) : this(tableName, fieldName, null)
        {
        }

        public Maximum(string tableName, string fieldName, string alias) : base("MAX", tableName, fieldName, alias)
        {
        }

        public static implicit operator Maximum(string value)
        {
            return new Maximum(value);
        }
    }
}