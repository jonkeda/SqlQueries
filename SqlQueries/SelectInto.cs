using Srt2.SqlQueries.Builders;
using Srt2.SqlQueries.Builders.Interfaces;
using Srt2.SqlQueries.Builders.Parts;

namespace Srt2.SqlQueries
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

        public override void CreateSql(SqlBuilder sb)
        {
            sb.SelectInto(this);
        }

    }
}