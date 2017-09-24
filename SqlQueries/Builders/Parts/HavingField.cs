using SqlQueries.Builders.Interfaces;
using SqlQueries.Functions;

namespace SqlQueries.Builders.Parts
{
    public class HavingField : ConditionOnField, IHavingCondition
    {
        public HavingField() : base(SqlOperator.Equal)
        {
        }

        public HavingField(Field field, Field toField) : this(field, SqlOperator.Equal, toField)
        {
        }

        public HavingField(Field field, SqlOperator sqlOperator, Field toField) : base(field, sqlOperator, toField)
        {

        }
    }
}