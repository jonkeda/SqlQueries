using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class ConditionCollection : Collection<Condition>
    {
        public SqlAndOr AndOr { get; set; }
    }
}