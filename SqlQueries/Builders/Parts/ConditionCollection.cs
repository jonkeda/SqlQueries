using System.Collections.ObjectModel;
using SqlQueries.Builders.Interfaces;

namespace SqlQueries.Builders.Parts
{
    public class ConditionCollection : Collection<ICondition>
    {
        public SqlAndOr AndOr { get; set; }
    }
}