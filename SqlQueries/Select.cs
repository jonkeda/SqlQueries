using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries
{
    public class Select : QueryBuilder, ITable, ITop, IOrderBy, IColumns, IGroupBy, IWhere, IHaving
    {
        public Select()
        {
        }

        public Select(Table tableName)
        {
            Table = tableName;
        }

        public Select(Table tableName, int top)
        {
            Table = tableName;
            Top = top;
        }

        public Top Top { get; set; }

        public Table Table { get; set; }

        public ColumnCollection Columns { get; set; } = new ColumnCollection();

        public OrderByCollection OrderBy { get; set; } = new OrderByCollection();

        public GroupByCollection GroupBy { get; set; } = new GroupByCollection();

        public WhereCollection Where { get; set; } = new WhereCollection();

        public HavingCollection Having { get; set; } = new HavingCollection();

    }
}