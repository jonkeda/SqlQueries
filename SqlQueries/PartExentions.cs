using SqlQueries.Parts;

namespace SqlQueries
{
    public static class PartExentions
    {
        #region TableName

        public static T Table<T>(this T query, Table name)
            where T : ITable
        {
            query.Table = name;
            return query;
        }
        #endregion

        #region Top

        public static T Top<T>(this T query, Top top)
            where T : ITop
        {
            query.Top = top;
            return query;
        }

        #endregion

        #region OrderBy

        public static T OrderBy<T>(this T query, Field field)
            where T : IOrderBy
        {
            query.OrderBy.Add(new OrderByField(field));
            return query;
        }

        public static T OrderByDescending<T>(this T query, Field field)
            where T : IOrderBy
        {
            query.OrderBy.Add(new OrderByField(field, true));
            return query;
        }

        #endregion

        #region Columns

        public static T Column<T>(this T query, Field field)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(field));
            return query;
        }

        public static T Columns<T>(this T query, FieldCollection fields)
            where T : IColumns
        {
            foreach (Field field in fields)
            { 
                query.Columns.Add(new ColumnField(field));
            }
            return query;
        }

        #endregion

    }
}
