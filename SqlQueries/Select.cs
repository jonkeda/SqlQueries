using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries
{
    public class Select : QueryBuilder, IFrom, ITop, IOrderBy, IColumns, IGroupBy, IWhere, IHaving, IJoins
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

        public Top Top { get; set; }

        public TableCollection From { get; set; } = new TableCollection();

        public ColumnCollection Columns { get; set; } = new ColumnCollection();

        public OrderByCollection OrderBy { get; set; } = new OrderByCollection();

        public GroupByCollection GroupBy { get; set; } = new GroupByCollection();

        public WhereCollection Where { get; set; } = new WhereCollection();

        public HavingCollection Having { get; set; } = new HavingCollection();

        public JoinCollection Joins { get; set; } = new JoinCollection();
    }
}