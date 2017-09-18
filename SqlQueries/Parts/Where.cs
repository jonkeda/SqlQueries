namespace SqlQueries.Parts
{
    public class Where
    {
        public Where()
        {
        }

        public Where(Field field, SqlOperator operand)
        {
            Field = field;
            Operand = operand;
        }

        public Field Field { get; set; }

        public SqlOperator Operand { get; set; }
    }
}
