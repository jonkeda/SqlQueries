using System;
using SqlQueries.Statements;

namespace SqlQueries.Parts
{


    public class ConditionOnField : ConditionOperator
    {
        public Field ToField { get; set; }

        public ConditionOnField()
        {
        }

        public ConditionOnField(Field field, SqlOperator operand, Field toField) : base(field, operand)
        {
            ToField = toField;
        }

        public override void Write(SqlBuilder sb, Action<SqlBuilder, Field> fieldWriter)
        {
            fieldWriter(sb, Field);
            Operator(sb, Operand);
            fieldWriter(sb, ToField);
        }
    }
}