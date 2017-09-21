using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries
{
    public class Select : QueryBuilder, 
        IFrom, 
        ITop, 
        IColumns,
        IOrderBy,
        IGroupBy, 
        IWhere, 
        IHaving, 
        IJoins, 
        IDistinct
    {
        public Select()
        {
        }

        public Select(Table tableName)
        {
            From.Add(tableName);
        }

        public Select(Table tableName, int top) : this(tableName)
        {
            Top = top;
        }

        public Select(Table tableName, ColumnCollection fields) : this(tableName)
        {
            Columns = fields;
        }

        public Top Top { get; set; }

        public TableCollection From { get; set; } = new TableCollection();

        public ColumnCollection Columns { get; set; } = new ColumnCollection();

        public OrderByCollection OrderBy { get; set; } = new OrderByCollection();

        public GroupByCollection GroupBy { get; set; } = new GroupByCollection();

        public ConditionCollection Where { get; set; } = new ConditionCollection();

        public ConditionCollection Having { get; set; } = new ConditionCollection();

        public JoinCollection Joins { get; set; } = new JoinCollection();

        public bool Distinct { get; set; }

        private ConditionCollection _conditions;
        private IFieldCollection _fields;

        public void SetCurrent(ConditionCollection conditions)
        {
            _conditions = conditions;
        }

        public void Add(Condition condition)
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

        public void SetCurrent(IFieldCollection fields)
        {
            _fields = fields;
        }

        public void Add(Field field)
        {
            if (_fields == null)
            {
                Columns.Add(field);
            }
            else
            {
                _fields.Add(field);
            }
        }
    }
}