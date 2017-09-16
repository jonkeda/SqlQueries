using System;

namespace SqlQueries.Statements
{
    public interface IQueryBuilder
    {
        string ToString(Type type);
    }
}