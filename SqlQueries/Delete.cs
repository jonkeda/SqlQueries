using SqlQueries.Builders;
using SqlQueries.Builders.Interfaces;
using SqlQueries.Builders.Parts;
using SqlQueries.Functions;

namespace SqlQueries
{
    public class Delete : QueryBuilder, IFrom, ITop, IOrderBy, IWhere
    {
        public Delete()
        {
        }

        public Delete(Table tableName)
        {
            From.Add(tableName);
        }

        public Delete(Table tableName, int top) : this(tableName)
        {
            Top = top;
        }

        public Top Top { get; set; }

        public TableCollection From { get; set; } = new TableCollection();

        public ConditionCollection Where { get; } = new ConditionCollection();

        public OrderByCollection OrderBy { get; } = new OrderByCollection();

        private ConditionCollection _conditions;


        public void SetCurrent(ConditionCollection conditions)
        {
            _conditions = conditions;
        }

        public void Add(ICondition condition)
        {
            if (_conditions == null)
            {
                Where.Add(condition);
            }
            else
            {
                _conditions.Add(condition);
            }
        }

        private IFieldCollection _fields;
        public void SetCurrent(IFieldCollection fields)
        {
            _fields = fields;
        }

        public void Add(Field field)
        {
            if (_fields == null)
            {
                OrderBy.Add(field);
            }
            else
            {
                _fields.Add(field);
            }
        }

        public override void CreateSql(SqlBuilder sb)
        {
            sb.Delete(this);
        }
    }
}