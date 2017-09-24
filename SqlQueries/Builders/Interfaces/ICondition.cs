namespace SqlQueries.Builders.Interfaces
{
    public interface ICondition
    {
        void Write(SqlBuilder sb);
    }
}