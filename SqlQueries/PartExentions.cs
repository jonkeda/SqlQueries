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

        #region GroupBy

        public static T GroupBy<T>(this T query, Field field)
            where T : IGroupBy
        {
            query.GroupBy.Add(new GroupByField(field));
            return query;
        }

        #endregion

        #region Where

        public static T Where<T>(this T query, Field field, SqlOperator sqlOperator, object value)
            where T : IWhere
        {
            query.Where.Add(new WhereValue(field, sqlOperator, value));
            return query;
        }

        public static T Where<T>(this T query, Field field, object value)
            where T : IWhere
        {
            return query.Where(field, SqlOperator.Equal, value);
        }

        public static T WhereField<T>(this T query, Field field, SqlOperator sqlOperator, Field toField)
            where T : IWhere
        {
            query.Where.Add(new WhereField(field, sqlOperator, toField));
            return query;
        }

        public static T WhereField<T>(this T query, Field field, Field toField)
            where T : IWhere
        {
            return query.WhereField(field, SqlOperator.Equal, toField);
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
