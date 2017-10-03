using System.Collections.ObjectModel;
using Srt2.SqlQueries.Functions;

namespace Srt2.SqlQueries.Builders.Parts
{
    public class UpdateFieldCollection : Collection<UpdateField>
    {
        public void Add(Field field, object value)
        {
            Add(new UpdateField(field, value));
        }
    }
}