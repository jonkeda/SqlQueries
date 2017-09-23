using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class ConditionCollection : Collection<ICondition>
    {
        public SqlAndOr AndOr { get; set; }
    }
}