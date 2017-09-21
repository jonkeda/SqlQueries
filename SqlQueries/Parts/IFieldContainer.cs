namespace SqlQueries.Parts
{
    public interface IFieldContainer
    {
        void SetCurrent(IFieldCollection conditions);
        void Add(Field field);
    }
}