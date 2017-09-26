using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries
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

        public TableSourceCollection From { get; set; } = new TableSourceCollection();

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