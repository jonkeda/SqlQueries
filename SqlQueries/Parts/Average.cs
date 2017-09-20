namespace SqlQueries.Parts
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