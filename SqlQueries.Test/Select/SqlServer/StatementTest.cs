using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class StatementTest
    {
        #region Simple

        [TestMethod]
        public void Constructor()
        {
            string statement = new SqlQueries.Select("Db.schem.TestTable").ToString(); 

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Properties()
        {
            string statement = new SqlQueries.Select
            {
                From = "[Db].[schem].[TestTable]"
            }.ToString();

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void Fluent()
        {
            string statement = new SqlQueries.Select().From("Db.schem.TestTable").ToString();

            Assert.AreEqual("SELECT * FROM [Db].[schem].[TestTable]", statement);
        }
        #endregion

        #region Top

        [TestMethod]
        public void ConstructorTop()
        {
            string statement = new SqlQueries.Select("Db.schem.TestTable", 10).ToString();

            Assert.AreEqual("SELECT TOP 10 * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void PropertiesTop()
        {
            string statement = new SqlQueries.Select
            {
                From = "[Db].[schem].[TestTable]",
                Top = 10
            }.ToString();

            Assert.AreEqual("SELECT TOP 10 * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void PropertiesTopPercentage()
        {
            string statement = new SqlQueries.Select
            {
                From = "[Db].[schem].[TestTable]",
                Top = new Top(10, true)
            }.ToString();

            Assert.AreEqual("SELECT TOP 10 PERCENTAGE * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void FluentTop()
        {
            string statement = new SqlQueries.Select().From("Db.schem.TestTable").Top(10).ToString();

            Assert.AreEqual("SELECT TOP 10 * FROM [Db].[schem].[TestTable]", statement);
        }

        [TestMethod]
        public void FluentTopPercentage()
        {
            string statement = new SqlQueries.Select().From("Db.schem.TestTable").Top(10, true).ToString();

            Assert.AreEqual("SELECT TOP 10 PERCENTAGE * FROM [Db].[schem].[TestTable]", statement);
        }

        #endregion

        #region Column Star

        private const string ColumnStarExpected = "SELECT [e].* FROM [DimEmployee] AS [e] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorColumnStar()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Column("e.*").OrderByField("LastName").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumnStar()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e",
                Columns =  "e.*"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        [TestMethod]
        public void FluentColumnStar()
        {
            string statement = new SqlQueries.Select().Column("e.*").From("DimEmployee e").OrderByField("LastName").ToString();

            Assert.AreEqual(ColumnStarExpected, statement);
        }

        #endregion

        #region Columns

        private const string ColumnsExpected = "SELECT [b], [a].[b], [a].[b] AS [c], [b] AS [c], AVG([x]), MIN([y]), MAX([z]), SUM([q]), COUNT([p]), COUNT(*) FROM [DimEmployee] AS [e] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorColumns()
        {
            string statement = new SqlQueries.Select("DimEmployee e")
                .Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]")
                .Average("x").Minimum("y").Maximum("z").Sum("q")
                .Count("p").Count()
                .OrderByField("LastName").ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void PropertiesColumns()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e",
                Columns = "[b], [a].[b], [a].[b] as [c]"
            };
            select.Columns.Add("[b] as [c]");
            select.Columns.Add(new Average("x"));

            select.Columns.Add(new Minimum("y"));
            select.Columns.Add(new Maximum("z"));

            select.Columns.Add(new Sum("q"));
            select.Columns.Add(new Count("p"));
            select.Columns.Add(new Count());

            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        [TestMethod]
        public void FluentColumns()
        {
            string statement = new SqlQueries.Select()
                .Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]")
                .Average("x").Minimum("y").Maximum("z").Sum("q")
                .Count("p").Count()
                .From("DimEmployee e").OrderByField("LastName").ToString();

            Assert.AreEqual(ColumnsExpected, statement);
        }

        #endregion

        #region Distinct

        private const string DistinctExpected = "SELECT DISTINCT [b], [a].[b], [a].[b] AS [c], [b] AS [c] FROM [DimEmployee] AS [e] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorDistinct()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Distinct().Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]").OrderByField("LastName").ToString();

            Assert.AreEqual(DistinctExpected, statement);
        }

        [TestMethod]
        public void PropertiesDistinct()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e",
                Columns = "[b], [a].[b], [a].[b] as [c], [b] as [c]",
                Distinct = true
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(DistinctExpected, statement);
        }

        [TestMethod]
        public void FluentDistinct()
        {
            string statement = new SqlQueries.Select().Distinct().Columns("[b], [a].[b], [a].[b] as [c], [b] as [c]").From("DimEmployee e").OrderByField("LastName").ToString();

            Assert.AreEqual(DistinctExpected, statement);
        }

        #endregion

        #region OrderBy

        private const string OrderByExpected = "SELECT * FROM [DimEmployee] ORDER BY [LastName]";

        [TestMethod]
        public void ConstructorOrderBy()
        {
            string statement = new SqlQueries.Select("DimEmployee").OrderByField("LastName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void PropertiesOrderBy()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.OrderBy.Add(new OrderByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        [TestMethod]
        public void FluentOrderBy()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").OrderByField("LastName").ToString();

            Assert.AreEqual(OrderByExpected, statement);
        }

        #endregion

        #region GroupBy

        private const string GroupByExpected = "SELECT * FROM [DimEmployee] GROUP BY [LastName]";

        [TestMethod]
        public void ConstructorGroupBy()
        {
            string statement = new SqlQueries.Select("DimEmployee").GroupBy("LastName").ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        [TestMethod]
        public void PropertiesGroupBy()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.GroupBy.Add(new GroupByField("LastName"));

            string statement = select.ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        [TestMethod]
        public void FluentGroupBy()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").GroupBy("LastName").ToString();

            Assert.AreEqual(GroupByExpected, statement);
        }

        #endregion

        #region Where

        private const string WhereExpected = "SELECT * FROM [DimEmployee] WHERE [LastName] = @p0 AND [Number] > [Count] AND [First] IS NULL AND [Second] IS NOT NULL";

        [TestMethod]
        public void ConstructorWhere()
        {
            string statement = new SqlQueries.Select("DimEmployee")
                .Where("LastName", "Daan")
                .WhereField("Number", SqlOperator.GreaterThan, "Count")
                .IsNull("First")
                .IsNotNull("Second")
                .ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        [TestMethod]
        public void PropertiesWhere()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.Where.Add(new EqualToValue("LastName", "Daan"));
            select.Where.Add(new GreaterThan("Number", "Count"));
            select.Where.Add(new IsNull("First"));
            select.Where.Add(new IsNotNull("Second"));

            string statement = select.ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        [TestMethod]
        public void FluentWhere()
        {
            string statement = new SqlQueries.Select()
                .From("DimEmployee")
                .Where("LastName", "Daan")
                .WhereField("Number", SqlOperator.GreaterThan, "Count")
                .IsNull("First")
                .IsNotNull("Second")
                .ToString();

            Assert.AreEqual(WhereExpected, statement);
        }

        #endregion

        #region Having

        private const string HavingExpected = "SELECT * FROM [DimEmployee] HAVING [LastName] = @p0 AND [Number] > [Count]";

        [TestMethod]
        public void ConstructorHaving()
        {
            string statement = new SqlQueries.Select("DimEmployee").Having("LastName", "Daan").HavingField("Number", SqlOperator.GreaterThan, "Count").ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        [TestMethod]
        public void PropertiesHaving()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee"
            };
            select.Having.Add(new HavingValue("LastName", "Daan"));
            select.Having.Add(new HavingField("Number", SqlOperator.GreaterThan, "Count"));

            string statement = select.ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        [TestMethod]
        public void FluentHaving()
        {
            string statement = new SqlQueries.Select().From("DimEmployee").Having("LastName", "Daan").HavingField("Number", SqlOperator.GreaterThan, "Count").ToString();

            Assert.AreEqual(HavingExpected, statement);
        }

        #endregion

        #region Join

        private const string JoinExpected = "SELECT * FROM [DimEmployee] AS [e] INNER JOIN [DimOrder] AS [o] ON [e].[Id] = [o].[EmployeeId]";

        [TestMethod]
        public void ConstructorJoin()
        {
            string statement = new SqlQueries.Select("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        [TestMethod]
        public void PropertiesJoin()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "DimEmployee e"
            };
            select.Joins.Add(new Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId"));

            string statement = select.ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        [TestMethod]
        public void FluentJoin()
        {
            string statement = new SqlQueries.Select().From("DimEmployee e").Join("DimOrder o", JoinType.Inner, "e.Id", "o.EmployeeId").ToString();

            Assert.AreEqual(JoinExpected, statement);
        }

        #endregion

        #region Where In

        private const string InExpected = @"SELECT * FROM [Customers] WHERE [Country] IN (SELECT [Country] FROM [Suppliers])";


        [TestMethod]
        public void ConstructorIn()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where()
                .In("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(InExpected, statement);
        }

        [TestMethod]
        public void PropertiesIn()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "Customers"
            };
           select.Where.Add(new In("Country", new SqlQueries.Select("Suppliers", "Country")));

            string statement = select.ToString();

            Assert.AreEqual(InExpected, statement);
        }

        [TestMethod]
        public void FluentIn()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .In("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(InExpected, statement);
        }

        #endregion

        #region Where Not in

        private const string NotInExpected = @"SELECT * FROM [Customers] WHERE [Country] NOT IN (SELECT [Country] FROM [Suppliers])";


        [TestMethod]
        public void ConstructorNotIn()
        {
            string statement = new SqlQueries.Select("Customers")
                .Where()
                .NotIn("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(NotInExpected, statement);
        }

        [TestMethod]
        public void PropertiesNotIn()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "Customers"
            };
            select.Where.Add(new NotIn("Country", new SqlQueries.Select("Suppliers", "Country")));

            string statement = select.ToString();

            Assert.AreEqual(NotInExpected, statement);
        }

        [TestMethod]
        public void FluentNotIn()
        {
            string statement = new SqlQueries.Select()
                .From("Customers")
                .NotIn("Country", new SqlQueries.Select("Suppliers", "Country"))
                .ToString();

            Assert.AreEqual(NotInExpected, statement);
        }

        #endregion

        #region Where Exist

        private const string ExistExpected = @"SELECT * FROM [Suppliers] WHERE EXISTS(SELECT [ProductName] FROM [Products])";


        [TestMethod]
        public void ConstructorExist()
        {
            string statement = new SqlQueries.Select("Suppliers")
                .Where()
                .Exists(new SqlQueries.Select("Products", "ProductName"))
                .ToString();

            Assert.AreEqual(ExistExpected, statement);
        }

        [TestMethod]
        public void PropertiesExist()
        {
            SqlQueries.Select select = new SqlQueries.Select
            {
                From = "Suppliers"
            };
            select.Where.Add(new Exists(new SqlQueries.Select("Products", "ProductName")));

            string statement = select.ToString();

            Assert.AreEqual(ExistExpected, statement);
        }

        [TestMethod]
        public void FluentExist()
        {
            string statement = new SqlQueries.Select()
                .From("Suppliers")
                .Exists(new SqlQueries.Select("Products", "ProductName"))
                .ToString();

            Assert.AreEqual(ExistExpected, statement);
        }

        #endregion

        #region Conditions

        private const string ConditionExpected = "SELECT [Orders].[OrderID], [Customers].[CustomerName] FROM [Orders] INNER JOIN [Customers] ON [Orders].[CustomerID] = [Customers].[CustomerID] WHERE [Customers].[Country] = @p0 GROUP BY [Orders].[OrderID], [Customers].[CustomerName] HAVING AVG([Order].[Amount]) > @p1 ORDER BY [Customers].[CustomerName], [Orders].[OrderID]";

        [TestMethod]
        public void FluentConditions()
        {
            string statement = new SqlQueries.Select()
                .Columns("Orders.OrderID, Customers.CustomerName").From("Orders")
                .Join("Customers", JoinType.Inner, "Orders.CustomerID", "Customers.CustomerID")
                .Where("Customers.Country", "Germany")
                .GroupBy("Orders.OrderID, Customers.CustomerName")
                .OrderBy("Customers.CustomerName, Orders.OrderID")
                .Having(new Average("Order.Amount"), SqlOperator.GreaterThan, 500)  
                .ToString();

            Assert.AreEqual(ConditionExpected, statement);
        }

        [TestMethod]
        public void FluentConditions2()
        {
            string statement = new SqlQueries.Select()
                .Columns("Orders.OrderID, Customers.CustomerName").From("Orders")
                .Join("Customers", JoinType.Inner).Equal("Orders.CustomerID", "Customers.CustomerID")
                .Where().EqualToValue("Customers.Country", "Germany")
                .GroupBy("Orders.OrderID, Customers.CustomerName")
                .OrderBy("Customers.CustomerName, Orders.OrderID")
                .Having().GreaterThanValue(new Average("Order.Amount"), 500)
                .ToString();

            Assert.AreEqual(ConditionExpected, statement);
        }

        #endregion
    }
}
