using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class HavingValue : ConditionOnValue, IHavingCondition
    {
        public HavingValue() : base(SqlOperator.Equal)
        {
        }

        public HavingValue(Field field, object value) : this(field, SqlOperator.Equal, value)
        {
        }

        public HavingValue(Field field, SqlOperator sqlOperator, object value) : base(field, sqlOperator, value)
        {
        }
    }
}