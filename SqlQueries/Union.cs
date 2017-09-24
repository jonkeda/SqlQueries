using System.Diagnostics.CodeAnalysis;
using SqlQueries.Builders;
using SqlQueries.Builders.Interfaces;
using SqlQueries.Builders.Parts;

namespace SqlQueries
{
    public class Union : QueryBuilder, IUnion, ISelectContainer
    {
        public Union()
        {
        }

        public Union(Select select1, Select select2)
        {
            Selects.Add(select1);
            Selects.Add(select2);
        }

        public SelectCollection Selects { get; } = new SelectCollection();

        [ExcludeFromCodeCoverage]
        public void SetCurrent(SelectCollection selects)
        {
           
        }

        public void Add(Select @select)
        {
            Selects.Add(select);
        }

        public override void CreateSql(SqlBuilder sb)
        {
            sb.Union(this);
        }
    }
}
