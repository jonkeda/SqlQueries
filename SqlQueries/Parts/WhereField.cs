namespace SqlQueries.Parts
{
    public class WhereField: Where
    {
        public WhereField()
        {
        }

        public WhereField(Field field, Field toField) : this(field, SqlOperator.Equal, toField)
        {
        }

        public WhereField(Field field, SqlOperator operand, Field toField) : base(field, operand)
        {
            ToField = toField;
        }

        public Field ToField { get; set; }
    }
}