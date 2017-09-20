using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{


    public abstract class ConditionOnField : ConditionOperator
    {
        public Field ToField { get; set; }

        protected ConditionOnField()
        {
        }

        protected ConditionOnField(Field field, SqlOperator operand, Field toField) : base(field, operand)
        {
            ToField = toField;
        }

        protected ConditionOnField(Field field, Field toField) : this(field, SqlOperator.Equal, toField)
        {
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            Operator(sb, Operand);
            fieldWriter(sb, ToField);
        }
    }
}