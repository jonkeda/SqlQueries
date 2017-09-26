using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
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