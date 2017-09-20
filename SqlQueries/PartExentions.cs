using SqlQueries.Parts;

namespace SqlQueries
{
    public static class PartExtentions
    {
        #region Table

        public static T Table<T>(this T query, Table name)
            where T : ITable
        {
            query.Table = name;
            return query;
        }


        #endregion

        #region From

        public static T From<T>(this T query, Table name)
            where T : IFrom
        {
            query.From.Add(name);
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

        public static T Top<T>(this T query, int top, bool percentage)
            where T : ITop
        {
            query.Top = new Top(top, percentage);
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

        public static T Where<T>(this T query)
            where T : IWhere
        {
            return query;
        }

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

        public static T IsNull<T>(this T query, Field field)
            where T : IWhere
        {
            query.Where.Add(new IsNull(field));
            return query;
        }

        public static T IsNotNull<T>(this T query, Field field)
            where T : IWhere
        {
            query.Where.Add(new IsNotNull(field));
            return query;
        }


        #endregion

        #region Having

        public static T Having<T>(this T query, Field field, SqlOperator sqlOperator, object value)
            where T : IHaving
        {
            query.Having.Add(new HavingValue(field, sqlOperator, value));
            return query;
        }

        public static T Having<T>(this T query, Field field, object value)
            where T : IHaving
        {
            return query.Having(field, SqlOperator.Equal, value);
        }

        public static T HavingField<T>(this T query, Field field, SqlOperator sqlOperator, Field toField)
            where T : IHaving
        {
            query.Having.Add(new HavingField(field, sqlOperator, toField));
            return query;
        }

        public static T HavingField<T>(this T query, Field field, Field toField)
            where T : IHaving
        {
            return query.HavingField(field, SqlOperator.Equal, toField);
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
            if (fields != null)
            {
                foreach (Field field in fields)
                {
                    query.Columns.Add(new ColumnField(field));
                }
            }
            return query;
        }

        #endregion

        #region Average

        public static T Average<T>(this T query, Average field)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(field));
            return query;
        }

        public static T Average<T>(this T query, string tableName, string fieldName)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Average(tableName, fieldName)));
            return query;
        }

        public static T Average<T>(this T query, string tableName, string fieldName, string alias)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Average(tableName, fieldName, alias)));
            return query;
        }

        #endregion

        #region Minimum

        public static T Minimum<T>(this T query, Minimum field)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(field));
            return query;
        }

        public static T Minimum<T>(this T query, string tableName, string fieldName)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Minimum(tableName, fieldName)));
            return query;
        }

        public static T Minimum<T>(this T query, string tableName, string fieldName, string alias)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Minimum(tableName, fieldName, alias)));
            return query;
        }

        #endregion

        #region Maximum

        public static T Maximum<T>(this T query, Maximum field)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(field));
            return query;
        }

        public static T Maximum<T>(this T query, string tableName, string fieldName)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Maximum(tableName, fieldName)));
            return query;
        }

        public static T Maximum<T>(this T query, string tableName, string fieldName, string alias)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Maximum(tableName, fieldName, alias)));
            return query;
        }

        #endregion

        #region Sum

        public static T Sum<T>(this T query, Sum field)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(field));
            return query;
        }

        public static T Sum<T>(this T query, string tableName, string fieldName)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Sum(tableName, fieldName)));
            return query;
        }

        public static T Sum<T>(this T query, string tableName, string fieldName, string alias)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Sum(tableName, fieldName, alias)));
            return query;
        }

        #endregion

        #region Count

        public static T Count<T>(this T query)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Count()));
            return query;
        }

        public static T Count<T>(this T query, Count field)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(field));
            return query;
        }

        public static T Count<T>(this T query, string tableName, string fieldName)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Count(tableName, fieldName)));
            return query;
        }

        public static T Count<T>(this T query, string tableName, string fieldName, string alias)
            where T : IColumns
        {
            query.Columns.Add(new ColumnField(new Count(tableName, fieldName, alias)));
            return query;
        }

        #endregion

        #region Joins

        public static T Join<T>(this T query, Table table, JoinType joinType, Field fromField, Field toField)
            where T : IJoins
        {
            query.Joins.Add(new Join(table, joinType, fromField, toField));
            return query;
        }

        #endregion

        #region Distinct

        public static T Distinct<T>(this T query)
            where T : IDistinct
        {
            query.Distinct = true;
            return query;
        }

        #endregion

        #region In

        public static T In<T>(this T query, Field field, Select select)
            where T : IWhere
        {
            query.Where.Add(new In(field, select));
            return query;
        }

        #endregion

        #region NotIn

        public static T NotIn<T>(this T query, Field field, Select select)
            where T : IWhere
        {
            query.Where.Add(new NotIn(field, select));
            return query;
        }

        #endregion

        #region NotIn

        public static T Exists<T>(this T query, Select select)
            where T : IWhere
        {
            query.Where.Add(new Exists(select));
            return query;
        }

        #endregion
    }
}
