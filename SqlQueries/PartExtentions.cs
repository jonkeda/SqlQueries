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

        #region Distinct

        public static T Distinct<T>(this T query)
            where T : IDistinct
        {
            query.Distinct = true;
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

        #region Columns

        private static void SetCurrentColumns<T>(T query)
            where T : IColumns
        {
            query.SetCurrent(query.Columns);
        }

        public static T Column<T>(this T query, Field field, params Field[] fields)
            where T : IColumns
        {
            SetCurrentColumns(query);
            query.Columns.Add(new ColumnField(field));
            foreach (Field aField in fields)
            {
                query.Columns.Add(new ColumnField(aField));
            }
            return query;
        }

        public static T Columns<T>(this T query)
            where T : IColumns
        {
            SetCurrentColumns(query);
            return query;
        }

        public static T Columns<T>(this T query, FieldCollection fields)
            where T : IColumns
        {
            SetCurrentColumns(query);
            if (fields != null)
            {
                foreach (Field field in fields)
                {
                    query.Columns.Add(new ColumnField(field));
                }
            }
            return query;
        }
        #region Average

        public static T Average<T>(this T query, Average field)
            where T : IFieldContainer
        {
            query.Add(field);
            return query;
        }

        public static T Average<T>(this T query, string tableName, string fieldName)
            where T : IFieldContainer
        {
            query.Add(new Average(tableName, fieldName));
            return query;
        }

        public static T Average<T>(this T query, string tableName, string fieldName, string alias)
            where T : IFieldContainer
        {
            query.Add(new Average(tableName, fieldName, alias));
            return query;
        }

        #endregion

        #region Minimum

        public static T Minimum<T>(this T query, Minimum field)
            where T : IFieldContainer
        {
            query.Add(field);
            return query;
        }

        public static T Minimum<T>(this T query, string tableName, string fieldName)
            where T : IFieldContainer
        {
            query.Add(new Minimum(tableName, fieldName));
            return query;
        }

        public static T Minimum<T>(this T query, string tableName, string fieldName, string alias)
            where T : IFieldContainer
        {
            query.Add(new Minimum(tableName, fieldName, alias));
            return query;
        }

        #endregion

        #region Maximum

        public static T Maximum<T>(this T query, Maximum field)
            where T : IFieldContainer
        {
            query.Add(field);
            return query;
        }

        public static T Maximum<T>(this T query, string tableName, string fieldName)
            where T : IFieldContainer
        {
            query.Add(new Maximum(tableName, fieldName));
            return query;
        }

        public static T Maximum<T>(this T query, string tableName, string fieldName, string alias)
            where T : IFieldContainer
        {
            query.Add(new Maximum(tableName, fieldName, alias));
            return query;
        }

        #endregion

        #region Sum

        public static T Sum<T>(this T query, Sum field)
            where T : IFieldContainer
        {
            query.Add(field);
            return query;
        }

        public static T Sum<T>(this T query, string tableName, string fieldName)
            where T : IFieldContainer
        {
            query.Add(new Sum(tableName, fieldName));
            return query;
        }

        public static T Sum<T>(this T query, string tableName, string fieldName, string alias)
            where T : IFieldContainer
        {
            query.Add(new Sum(tableName, fieldName, alias));
            return query;
        }

        #endregion

        #region Count

        public static T Count<T>(this T query)
            where T : IFieldContainer
        {
            query.Add(new Count());
            return query;
        }

        public static T Count<T>(this T query, Count field)
            where T : IFieldContainer
        {
            query.Add(field);
            return query;
        }

        public static T Count<T>(this T query, string tableName, string fieldName)
            where T : IFieldContainer
        {
            query.Add(new Count(tableName, fieldName));
            return query;
        }

        public static T Count<T>(this T query, string tableName, string fieldName, string alias)
            where T : IFieldContainer
        {
            query.Add(new Count(tableName, fieldName, alias));
            return query;
        }

        #endregion
        #endregion

        #region From

        public static T From<T>(this T query, Table name)
            where T : IFrom
        {
            query.From.Add(name);
            return query;
        }

        #endregion

        #region Joins

        #region Join

        private static void SetCurrentJoin<T>(T query, Join @join)
            where T : IJoins
        {
            query.SetCurrent(join.On);
        }

        public static T Join<T>(this T query, Table table, JoinType joinType)
            where T : IJoins
        {
            Join join = new Join(table, joinType);
            SetCurrentJoin(query, @join);
            query.Joins.Add(join);
            return query;
        }

        public static T Join<T>(this T query, Table table, JoinType joinType, Field fromField, Field toField)
            where T : IJoins
        {
            Join join = new Join(table, joinType, fromField, toField);
            SetCurrentJoin(query, @join);
            query.Joins.Add(join);
            return query;
        }

        #endregion

        #region InnerJoin

        public static T InnerJoin<T>(this T query, Table table)
            where T : IJoins
        {
            return Join(query, table, JoinType.Inner);
        }

        public static T InnerJoin<T>(this T query, Table table, Field fromField, Field toField)
            where T : IJoins
        {
            return Join(query, table, JoinType.Inner, fromField, toField);
        }

        #endregion

        #region FullOuterJoin

        public static T FullOuterJoin<T>(this T query, Table table)
            where T : IJoins
        {
            return Join(query, table, JoinType.FullOuter);
        }

        public static T FullOuterJoin<T>(this T query, Table table, Field fromField, Field toField)
            where T : IJoins
        {
            return Join(query, table, JoinType.FullOuter, fromField, toField);
        }

        #endregion

        #region RightJoin

        public static T RightJoin<T>(this T query, Table table)
            where T : IJoins
        {
            return Join(query, table, JoinType.Right);
        }

        public static T RightJoin<T>(this T query, Table table, Field fromField, Field toField)
            where T : IJoins
        {
            return Join(query, table, JoinType.Right, fromField, toField);
        }

        #endregion

        #region LeftJoin

        public static T LeftJoin<T>(this T query, Table table)
            where T : IJoins
        {
            return Join(query, table, JoinType.Left);
        }

        public static T LeftJoin<T>(this T query, Table table, Field fromField, Field toField)
            where T : IJoins
        {
            return Join(query, table, JoinType.Left, fromField, toField);
        }

        #endregion

        #endregion

        #region Where

        private static void SetCurrentWhere<T>(T query)
            where T :IWhere
        {
            query.SetCurrent(query.Where);
        }

        public static T Where<T>(this T query)
            where T : IWhere
        {
            SetCurrentWhere(query);
            return query;
        }

        public static T Where<T>(this T query, Field field, SqlOperator sqlOperator, object value)
            where T : IWhere
        {
            SetCurrentWhere(query);
            query.Add(new ConditionOnValue(field, sqlOperator, value));
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
            SetCurrentWhere(query);
            query.Add(new ConditionOnField(field, sqlOperator, toField));
            return query;
        }

        public static T Where<T>(this T query, Condition condition)
            where T : IWhere
        {
            SetCurrentWhere(query);
            query.Add(condition);
            return query;
        }

        public static T WhereField<T>(this T query, Field field, Field toField)
            where T : IWhere
        {
            return query.WhereField(field, SqlOperator.Equal, toField);
        }
        #endregion

        #region Group By

        private static void SetCurrentGroupBy<T>(T query)
            where T : IGroupBy
        {
            query.SetCurrent(query.GroupBy);
        }

        public static T GroupByField<T>(this T query, Field field)
            where T : IGroupBy
        {
            SetCurrentGroupBy(query);
            query.GroupBy.Add(new GroupByField(field));
            return query;
        }

        public static T GroupBy<T>(this T query, GroupByField field)
            where T : IGroupBy
        {
            SetCurrentGroupBy(query);
            query.GroupBy.Add(field);
            return query;
        }

        public static T GroupBy<T>(this T query, FieldCollection fields)
            where T : IGroupBy
        {
            SetCurrentGroupBy(query);
            if (fields != null)
            {
                foreach (Field field in fields)
                {
                    query.GroupBy.Add(new GroupByField(field));
                }
            }
            return query;
        }

        #endregion

        #region Having

        private static void SetCurrentHaving<T>(T query)
            where T : IHaving
        {
            query.SetCurrent(query.Having);
        }

        public static T Having<T>(this T query)
            where T : IHaving
        {
            SetCurrentHaving(query);
            return query;
        }

        public static T Having<T>(this T query, Field field, SqlOperator sqlOperator, object value)
            where T : IHaving
        {
            SetCurrentHaving(query);
            query.Add(new HavingValue(field, sqlOperator, value));
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
            SetCurrentHaving(query);
            query.Add(new HavingField(field, sqlOperator, toField));
            return query;
        }

        public static T HavingField<T>(this T query, Field field, Field toField)
            where T : IHaving
        {
            return query.HavingField(field, SqlOperator.Equal, toField);
        }

        #endregion

        #region Order By

        private static void SetCurrentOrderby<T>(T query)
            where T : IOrderBy
        {
            query.SetCurrent(query.OrderBy);
        }

        public static T OrderByField<T>(this T query, Field field)
            where T : IOrderBy
        {
            SetCurrentOrderby(query);
            query.OrderBy.Add(new OrderByField(field));
            return query;
        }

        public static T OrderByFieldDescending<T>(this T query, Field field)
            where T : IOrderBy
        {
            SetCurrentOrderby(query);
            query.OrderBy.Add(new OrderByField(field, true));
            return query;
        }

        public static T OrderBy<T>(this T query, FieldCollection fields)
            where T : IOrderBy
        {
            SetCurrentOrderby(query);
            if (fields != null)
            {
                foreach (Field field in fields)
                {
                    query.OrderBy.Add(new OrderByField(field));
                }
            }
            return query;
        }

        public static T OrderByDescending<T>(this T query, FieldCollection fields)
            where T : IOrderBy
        {
            SetCurrentOrderby(query);
            if (fields != null)
            {
                foreach (Field field in fields)
                {
                    query.OrderBy.Add(new OrderByField(field, true));
                }
            }
            return query;
        }

        #endregion

        #region Conditions

        #region Equals

        public static T Equal<T>(this T query, Field field, Field toField)
            where T : IConditionContainer
        {
            query.Add(new Equal(field, toField));
            return query;
        }

        public static T EqualToValue<T>(this T query, Field field, object value)
            where T : IConditionContainer
        {
            query.Add(new EqualToValue(field, value));
            return query;
        }

        #endregion

        #region NotEquals

        public static T NotEqual<T>(this T query, Field field, Field toField)
            where T : IConditionContainer
        {
            query.Add(new NotEqual(field, toField));
            return query;
        }

        public static T NotEqualToValue<T>(this T query, Field field, object value)
            where T : IConditionContainer
        {
            query.Add(new NotEqualToValue(field, value));
            return query;
        }

        #endregion

        #region GreaterThan

        public static T GreaterThan<T>(this T query, Field field, Field toField)
            where T : IConditionContainer
        {
            query.Add(new GreaterThan(field, toField));
            return query;
        }

        public static T GreaterThanValue<T>(this T query, Field field, object value)
            where T : IConditionContainer
        {
            query.Add(new GreaterThanValue(field, value));
            return query;
        }

        #endregion

        #region GreaterOrEqual

        public static T GreaterOrEqual<T>(this T query, Field field, Field toField)
            where T : IConditionContainer
        {
            query.Add(new GreaterOrEqual(field, toField));
            return query;
        }

        public static T GreaterOrEqualThanValue<T>(this T query, Field field, object value)
            where T : IConditionContainer
        {
            query.Add(new GreaterOrEqualThanValue(field, value));
            return query;
        }

        #endregion


        #region LessThan

        public static T LessThan<T>(this T query, Field field, Field toField)
            where T : IConditionContainer
        {
            query.Add(new LessThan(field, toField));
            return query;
        }

        public static T LessThanValue<T>(this T query, Field field, object value)
            where T : IConditionContainer
        {
            query.Add(new LessThanValue(field, value));
            return query;
        }

        #endregion

        #region LessOrEqual

        public static T LessOrEqual<T>(this T query, Field field, Field toField)
            where T : IConditionContainer
        {
            query.Add(new LessOrEqual(field, toField));
            return query;
        }

        public static T LessOrEqualThanValue<T>(this T query, Field field, object value)
            where T : IConditionContainer
        {
            query.Add(new LessOrEqualThanValue(field, value));
            return query;
        }

        #endregion




        #region IsNull

        public static T IsNull<T>(this T query, Field field)
            where T : IConditionContainer
        {
            query.Add(new IsNull(field));
            return query;
        }

        #endregion

        #region IsNotNull

        public static T IsNotNull<T>(this T query, Field field)
            where T : IConditionContainer
        {
            query.Add(new IsNotNull(field));
            return query;
        }

        #endregion

        #region In

        public static T In<T>(this T query, Field field, Select select)
            where T : IConditionContainer
        {
            query.Add(new In(field, select));
            return query;
        }

        #endregion

        #region NotIn

        public static T NotIn<T>(this T query, Field field, Select select)
            where T : IConditionContainer
        {
            query.Add(new NotIn(field, select));
            return query;
        }

        #endregion

        #region Exists

        public static T Exists<T>(this T query, Select select)
            where T : IConditionContainer
        {
            query.Add(new Exists(select));
            return query;
        }

        #endregion

        #region All

        public static T All<T>(this T query, Field field, SqlOperator sqlOperator, Select select)
            where T : IConditionContainer
        {
            query.Add(new All(field, sqlOperator, select));
            return query;
        }

        #endregion

        #region Any

        public static T Any<T>(this T query, Field field, SqlOperator sqlOperator, Select select)
            where T : IConditionContainer
        {
            query.Add(new Any(field, sqlOperator, select));
            return query;
        }

        #endregion

        #region Like

        public static T Like<T>(this T query, Field field, string pattern)
            where T : IConditionContainer
        {
            query.Add(new Like(field, pattern));
            return query;
        }

        #endregion

        #region Between

        public static T Between<T>(this T query, Field field, object fromValue, object toValue)
            where T : IConditionContainer
        {
            query.Add(new Between(field, fromValue, toValue));
            return query;
        }

        #endregion

        #endregion
    }
}
