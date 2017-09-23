using SqlQueries.Statements;

namespace SqlQueries.Parts
{
    public abstract class Function : Field
    {
        private readonly string _functionName;

        protected Function(string functionName, string fullName) : base(fullName)
        {
            _functionName = functionName;
        }

        protected Function(string functionName, string tableName, string fieldName, string alias) : base(tableName, fieldName, alias)
        {
            _functionName = functionName;
        }

        public override void Write(SqlBuilder sb)
        {
            sb.Append(_functionName);
            sb.Append("(");

            if (!string.IsNullOrEmpty(TableName))
            {
                sb.Append("[");
                sb.Append(TableName);
                sb.Append("].");
            }
            if (FieldName == "*")
            {
                sb.Append("*");
            }
            else
            {
                sb.Append("[");
                sb.Append(FieldName);
                sb.Append("]");
            }
            sb.Append(")");

            if (!string.IsNullOrEmpty(Alias))
            {
                sb.Append(" AS [");
                sb.Append(Alias);
                sb.Append("]");
            }
        }
    }
}