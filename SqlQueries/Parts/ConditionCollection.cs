using System.Collections.ObjectModel;

namespace SqlQueries.Parts
{
    public class ConditionCollection<T> :Collection<T>
    {
        public SqlAndOr AndOr { get; set; }
    }
}