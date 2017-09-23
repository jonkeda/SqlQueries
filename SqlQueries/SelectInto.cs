using SqlQueries.Parts;

namespace SqlQueries
{
    public class SelectInto : Select, IInto
    {
        public SelectInto()
        {
        }

        public SelectInto(Table tableName) : base(tableName)
        {
        }

        public SelectInto(Table tableName, ColumnCollection fields) : base(tableName, fields)
        {
        }


        public SelectInto(Table tableName, ColumnCollection fields, Table into) : base(tableName, fields)
        {
            Into = into;
        }

        public Table Into { get; set; }
    }
}