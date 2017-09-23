using SqlQueries.Parts;
using SqlQueries.Statements;

namespace SqlQueries
{
    public class InsertIntoSelect : QueryBuilder, IInto, IColumns, ISelect
    {
        public InsertIntoSelect()
        {
        }

        public InsertIntoSelect(Table intoTable) : this(intoTable, null, null)
        {
        }

        public InsertIntoSelect(Table intoTable, ColumnCollection fields) : this(intoTable, fields, null)
        {
        }

        public InsertIntoSelect(Table intoTable, ColumnCollection fields, Select select)
        {
            Into = intoTable;
            if (fields != null)
            {
                Columns.AddFields(fields);
            }
            Select = select;
        }

        public Table Into { get; set; }

        public Select Select { get; set; }

        public void SetCurrent(IFieldCollection conditions)
        {
        }

        public void Add(Field field)
        {
            Columns.Add(field);
        }

        public ColumnCollection Columns { get; } = new ColumnCollection();
    }
}