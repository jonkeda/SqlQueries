using System.Collections.ObjectModel;
using Srt2.SqlQueries.Builders.Interfaces;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class ConditionCollection : Collection<ICondition>
    {
        public SqlAndOr AndOr { get; set; }
    }
}